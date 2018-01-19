using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using System.Transactions;
using AutoMapper;
using Inke.Common.Exceptions;
using System.Data.Entity;
using EntityFramework.Extensions;
using System.IO;


namespace InkeServer.Service.Impl
{
    public class MerchantImgService : ServiceBase, IMerchantImgService
    {
        //标记为注入对象
        [InjectionConstructor]
        public MerchantImgService() { }
        /// <summary>
        /// 添加商家图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(AddOrUpdateMerchantImg param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            bool isadd = true;
            //商家logo只存在一张
            int type = (int)MerchantImgType.Logo;
            if (param.Img_Type == type)
            {
                var logo = (from e in Entities.Bas_MerchantImg
                            where e.Merchant_ID == param.Merchant_ID && e.Img_Type == type
                            select e).FirstOrDefault();
                if (logo != null)
                {
                    isadd = false;
                    //更新logo
                    logo.Img_IsIndex = param.Img_IsIndex;
                    logo.Img_Type = param.Img_Type;
                    logo.Img_Url = param.Img_Url;
                    logo.Merchant_ID = param.Merchant_ID;
                    ////先删除物理图片
                    //var path = System.Web.HttpContext.Current.Server.MapPath(logo.Img_Url);
                    //System.IO.FileInfo file = new System.IO.FileInfo(logo.Img_Url);
                    //if (file.Exists)
                    //{
                    //    if ((file.Attributes & FileAttributes.ReadOnly) > 0)
                    //        file.Attributes ^= FileAttributes.ReadOnly;
                    //    file.Delete();
                    //}
                }
            }
            if (isadd)
            {
                Bas_MerchantImg model = param.MapTo<Bas_MerchantImg>();
                model.Img_ID = Inke.Common.Helpers.GUID.CreateGUID();
                Entities.Bas_MerchantImg.Add(model);
            }
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.AddFaild.Name());
            return true;
        }

        /// <summary>
        ///  更新商家图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(AddOrUpdateMerchantImg param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (!Entities.Bas_MerchantImg.Any(e => e.Img_ID == param.Img_ID))
                throw new BusinessException(ResultCode.DataNotFound.Name());
            //商家logo只存在一张
            bool islogo = true;
            int type = (int)MerchantImgType.Logo;
            if (param.Img_Type == type)
            {
                var logo = (from e in Entities.Bas_MerchantImg
                            where e.Merchant_ID == param.Merchant_ID && e.Img_Type == type && e.Img_ID != param.Img_ID
                            select e).FirstOrDefault();
                if (logo != null)
                {
                    islogo = false;
                    //更新logo
                    logo.Img_IsIndex = param.Img_IsIndex;
                    logo.Img_Type = param.Img_Type;
                    logo.Img_Url = param.Img_Url;
                    logo.Merchant_ID = param.Merchant_ID;
                }
            }
            if (islogo)
            {
                Bas_MerchantImg model = param.MapTo<Bas_MerchantImg>();
                Entities.Entry(model).State = EntityState.Modified;
            }
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            return true;
        }
        /// <summary>
        /// 删除商家图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Delete(OperationBaseRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //先循环删除物理图片
            //if (!string.IsNullOrEmpty(param.Record_ID))
            //{
            //    var ids = param.Record_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    param.Record_ID = string.Join(",", ids);
            //    foreach (var id in ids)
            //    {
            //        var info = (from e in Entities.Bas_MerchantImg
            //                    where e.Img_ID == param.Record_ID
            //                    select e).FirstOrDefault();
            //        if (info != null)
            //        {
            //            System.IO.FileInfo file = new System.IO.FileInfo( System.Web.HttpContext.Current.Server.MapPath(info.Img_Url));
            //            if (file.Exists)
            //            {
            //                if ((file.Attributes & FileAttributes.ReadOnly) > 0)
            //                    file.Attributes ^= FileAttributes.ReadOnly;
            //                file.Delete();
            //            }                        }
            //    }
            //}
            int row = Entities.Bas_MerchantImg.Where(t => param.Record_ID.Contains(t.Img_ID)).Delete();
            if (row == 0)
                throw new BusinessException(ResultCode.DeleteFaild.Name());

            return true;
        }
        /// <summary>
        /// 根据图片地址删除商家图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool DeleteByUrl(MerchantImgDelete param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            int row = Entities.Bas_MerchantImg.Where(t => t.Merchant_ID==param.Merchant_ID&&t.Img_Type==param.Img_Type&&t.Img_Url==param.Img_Url).Delete();
            if (row == 0)
                throw new BusinessException(ResultCode.DeleteFaild.Name());

            return true;
        }
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MerchantImg GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from e in Entities.Bas_MerchantImg
                        where e.Img_ID == param.Record_ID
                        select e).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            return info.MapTo<MerchantImg>();
        }
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MerchantImg> GetList(MerchantImgListRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from e in Entities.Bas_MerchantImg
                        where e.Merchant_ID == param.Merchant_ID
                        select e);
            list = list.WhereIf(t => t.Img_Type == param.Img_Type, param.Img_Type > 0);
            return list.MapTo<MerchantImg>();
        }
    }
}
