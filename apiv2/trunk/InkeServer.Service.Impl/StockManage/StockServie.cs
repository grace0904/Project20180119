using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using InkeServer.Enums;
using System.Transactions;
using Inke.Common.Exceptions;
using AutoMapper;
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 库存管理 服务类
    /// </summary>
    public class StockServie : ServiceBase, IStockServie
    {
        //标记为注入对象
        [InjectionConstructor]
        public StockServie() { }
        /// <summary>
        /// 分页查询 入库记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<StockQueryResult> Query(StockQueryRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_ProductStorage
                         join b in Entities.Bas_ProductStorageBatch on a.ProductStorageBatch_ID equals b.ProductStorageBatch_ID
                         join c in Entities.Bas_ShopProducts on a.ShopProduct_ID equals c.ShopProduct_ID
                         let shop = (from s in Entities.Bas_Shop where s.Shop_ID == a.Shop_ID select s).FirstOrDefault()
                         where a.Del != 1 && b.Del != 1 && a.Merchant_ID == param.Merchant_ID && b.Merchant_ID == param.Merchant_ID
                        && (string.IsNullOrEmpty(param.MerchantBaseInfo_ID) || c.MerchantBaseInfo_ID == param.MerchantBaseInfo_ID)
                         && (string.IsNullOrEmpty(param.Shop_ID) || a.Shop_ID == param.Shop_ID)
                         select new StockQueryResult
                         {
                             ProductStorage_ID = a.ProductStorage_ID,
                             ProductStorageBatch_ID = b.ProductStorageBatch_ID,
                             StorageBatch_Num = b.StorageBatch_Num,
                             Product_Code = c.Code,
                             Product_Name = c.Name,
                             Product_Unit = c.Unit,
                             Storage_Number = a.StorageNum,
                             Storage_Price = a.ProductPrice,
                             StorageTime = a.StarageTime,
                             Shop_Name = shop == null ? "" : shop.Shop_Name
                         });
            query = query.WhereIf(t => t.Product_Name.IndexOf(param.Product_Name) > -1, param.Product_Name.NotNullOrEmpty());
            query = query.WhereIf(t => t.Product_Code.IndexOf(param.Product_Code) > -1, param.Product_Code.NotNullOrEmpty());
            query = query.WhereIf(t => t.StorageTime >= param.DateFrom, param.DateFrom.HasValue);
            query = query.WhereIf(t => t.StorageTime <= param.DateTo, param.DateTo.HasValue);

            KeySelectors<StockQueryResult, DefaultSortBy> _keySelectors =
            new KeySelectors<StockQueryResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.StorageBatch_Num);
            return QueryPaginate<StockQueryResult, StockQueryResult>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="param"></param>
        public StorageBatchID Add(AddOrUpdateStockRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                Bas_ProductStorageBatch stock = new Bas_ProductStorageBatch();
                stock.ProductStorageBatch_ID = Inke.Common.Helpers.GUID.CreateGUID();
                stock.StorageBatch_Num = GetStockBatch(param.Merchant_ID, param.Shop_ID);
                stock.Handler = param.Handler;
                stock.Merchant_ID = param.Merchant_ID;
                stock.Shop_ID = param.Shop_ID;
                stock.Memo = param.Remark;
                stock.StorageTime = param.StorageTime;
                stock.AddTime = DateTime.Now;
                stock.OperationTime = DateTime.Now;
                stock.Operator = param.Operator;
                stock.Del = 0;
                Entities.Bas_ProductStorageBatch.Add(stock);
                if (param.StorageProductList != null && param.StorageProductList.Count > 0)
                {
                    //排除入库数量为0的记录
                    param.StorageProductList.RemoveAll(t => t.StorageNum <= 0);
                    var list = new List<Bas_ProductStorage>();
                    foreach (var item in param.StorageProductList)
                    {
                        Bas_ProductStorage product = item.MapTo<Bas_ProductStorage>();
                        product.ProductStorage_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        product.ProductStorageBatch_ID = stock.ProductStorageBatch_ID;
                        product.Merchant_ID = param.Merchant_ID;
                        product.Shop_ID = param.Shop_ID;
                        product.AddTime = DateTime.Now;
                        product.OperationTime = DateTime.Now;
                        product.Opertaor = param.Operator;
                        product.Del = 0;
                        product.StarageTime = param.StorageTime;
                        product.LowerLimit = 0;
                        list.Add(product);
                    }
                    if (list.Count > 0)
                    {
                        Entities.Bas_ProductStorage.AddRange(list);
                    }
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.AddFaild.Name());
                StorageBatchID result = new StorageBatchID { ProductStorageBatch_ID = stock.ProductStorageBatch_ID };
                scope.Complete();
                return result;
            }


        }
        /// <summary>
        /// 修改入库信息
        /// </summary>
        /// <param name="param"></param>
        public StorageBatchID Update(AddOrUpdateStockRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                Bas_ProductStorageBatch stock = (from s in Entities.Bas_ProductStorageBatch where s.ProductStorageBatch_ID == param.ProductStorageBatch_ID select s).FirstOrDefault();
                if (stock == null)
                    throw new BusinessException(ResultCode.DataNotFound.Name());

                stock.Handler = param.Handler;
                stock.Merchant_ID = param.Merchant_ID;
                stock.Shop_ID = param.Shop_ID;
                stock.Memo = param.Remark;
                stock.OperationTime = DateTime.Now;
                stock.Operator = param.Operator;
                stock.StorageTime = param.StorageTime;
                //先删除原有入库产品(物理删除)
                Entities.Bas_ProductStorage.Where(t => t.Merchant_ID == stock.Merchant_ID && t.Shop_ID == stock.Shop_ID && t.ProductStorageBatch_ID == stock.ProductStorageBatch_ID).Delete();
                if (param.StorageProductList != null && param.StorageProductList.Count > 0)
                {
                    //排除入库数量为0的记录
                    param.StorageProductList.RemoveAll(t => t.StorageNum <= 0);
                    var list = new List<Bas_ProductStorage>();
                    foreach (var item in param.StorageProductList)
                    {
                        Bas_ProductStorage product = item.MapTo<Bas_ProductStorage>();
                        product.ProductStorage_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        product.ProductStorageBatch_ID = stock.ProductStorageBatch_ID;
                        product.Merchant_ID = param.Merchant_ID;
                        product.Shop_ID = param.Shop_ID;
                        product.AddTime = DateTime.Now;
                        product.OperationTime = DateTime.Now;
                        product.Opertaor = param.Operator;
                        product.Del = 0;
                        product.StarageTime = param.StorageTime;
                        product.LowerLimit = 0;
                        list.Add(product);
                    }
                    if (list.Count > 0)
                    {
                        Entities.Bas_ProductStorage.AddRange(list);
                    }
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.AddFaild.Name());
                StorageBatchID result = new StorageBatchID { ProductStorageBatch_ID = stock.ProductStorageBatch_ID };
                scope.Complete();
                return result;
            }


        }
        /// <summary>
        /// 删除入库记录
        /// </summary>
        /// <param name="param"></param>
        public void Delete(OperationBaseRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (!string.IsNullOrEmpty(param.Record_ID))
                {
                    param.Record_ID = string.Join(",", param.Record_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
                int row = Entities.Bas_ProductStorageBatch
                .Where(t => param.Record_ID.Contains(t.ProductStorageBatch_ID))
                .Update(t => new Bas_ProductStorageBatch { Del = 1, OperationTime = DateTime.Now, Operator = param.Operator });

                //其下入库产品记录标记为已删除
                Entities.Bas_ProductStorage.Where(t => param.Record_ID.Contains(t.ProductStorageBatch_ID)).Update(t => new Bas_ProductStorage { Del = 1, OperationTime = DateTime.Now, Opertaor = param.Operator });

                if (row == 0)
                    throw new BusinessException(ResultCode.DeleteFaild.Name());
                scope.Complete();
            }
        }

        /// <summary>
        /// 生成库存批次
        /// </summary>
        /// <returns></returns>
        private string GetStockBatch(string merchantId, string shopId)
        {
            /*单号生成规则
             * ST(Storage)+日期+当天入库批次
             */
            var maxBatch = (from s in Entities.Bas_ProductStorageBatch where s.Merchant_ID == merchantId && s.Shop_ID == shopId && s.Del != 1 select s).Count() + 1;
            var batch = "";
            if (maxBatch < 10)
            {
                batch += "00" + maxBatch;
            }
            else if (maxBatch < 100)
            {
                batch += "0" + maxBatch;
            }
            else
            {
                batch = maxBatch.ToString();
            }
            var result = "ST" + DateTime.Now.ToString("yyyyMMdd") + batch;
            return result;
        }

        /// <summary>
        /// 根据主键ID获得入库单详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public StockInfoResult GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from s in Entities.Bas_ProductStorageBatch
                        where s.ProductStorageBatch_ID == param.Record_ID
                        select s).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            StockInfoResult data = new StockInfoResult();
            data.ProductStorageBatch_ID = info.ProductStorageBatch_ID;
            data.Handler = info.Handler;
            var staff = (from s in Entities.Bas_ShopEmployee where s.Shop_ID == info.Shop_ID && s.Employee_ID == info.Handler select s).FirstOrDefault();
            data.Handler_Name = staff.Employee_Name;
            data.Shop_ID = info.Shop_ID;
            var shop = (from s in Entities.Bas_Shop where s.Shop_ID == info.Shop_ID select s).FirstOrDefault();
            data.Shop_Name = shop == null ? "" : shop.Shop_Name;
            data.StorageTime = info.StorageTime;
            data.Remark = info.Memo;
            data.StorageBatch_Num = info.StorageBatch_Num;
            //得到产品数据集合
            var productlist = (from t in Entities.Bas_ProductStorage
                               join p in Entities.Bas_ShopProducts on t.ShopProduct_ID equals p.ShopProduct_ID
                               join b1 in Entities.Bas_MerchantBaseInfo on p.MerchantBaseInfo_ID equals b1.MerchantBaseInfo_ID into tb
                               from b in tb.DefaultIfEmpty()
                               where t.Del != 1 && t.ProductStorageBatch_ID == param.Record_ID
                               select new StorageProductInfoReuslt
                               {
                                   MerchantBaseInfo_ID = p.MerchantBaseInfo_ID,
                                   MerchantBaseInfo_Name = b == null ? "" : b.MerchantBaseInfo_Name,
                                   Product_Code = p.Code,
                                   Product_ID = t.Product_ID,
                                   Product_Name = p.Name,
                                   Product_Unit = p.Unit,
                                   Remark = t.Memo == null ? "" : t.Memo,
                                   ShopProduct_ID = t.ShopProduct_ID,
                                   Storage_Number = t.StorageNum,
                                   Storage_Price = t.ProductPrice
                               }).ToList();
            data.StorageProductList = productlist;
            return data;
        }
        /// <summary>
        /// 产品库存统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<StorageStatisticsResult> GetStorageStatisticsData(StockQueryRequest param)
        {

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //获取统计结果
            var query = Entities.Rpt_ProductStorageStatistics(param.Merchant_ID, param.Shop_ID, param.DateFrom.ToString(), param.DateTo.ToString(), param.Product_Name, param.Product_Code, param.MerchantBaseInfo_ID).MapTo<StorageStatisticsResult>().AsQueryable();

            var totalCount = query.Count();
            if (totalCount <= 0)
            {
                return new PaginationResult<StorageStatisticsResult> { Items = new List<StorageStatisticsResult>(), TotalCount = 0 };
            }
            //分页处理
            KeySelectors<StorageStatisticsResult, DefaultSortBy> _keySelector =
        new KeySelectors<StorageStatisticsResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Product_Name);
            var paging = PaginationHelper.GetPaging(param.PageIndex, param.PageSize, DefaultSortBy.Default);
            var list = query.Paginater(_keySelector, paging);
            var final = list.ToList();
            return new PaginationResult<StorageStatisticsResult> { Items = final, TotalCount = totalCount };

        }
    }
}
