using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IComboProductService
    {
        /// <summary>
        /// 获取指定套餐组下的套餐产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<GetComboProductQueryResult> GetListByComboGroupID(GetComboProductListRequest param);
        /// <summary>
        /// 分页获取指定套餐组下的套餐产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<GetComboProductQueryResult> GetListByComboGroupIDPage(GetComboProductPageRequest param);
        /// <summary>
        /// 获取套餐组产品详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ComboGroupProductInfoResult GetInfo(ComboGroupProductInfoRequest param);
        /// <summary>
        /// 新增套餐产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(AddOrUpdateComboProduct param);
        /// <summary>
        /// 修改套餐产品信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Update(AddOrUpdateComboProduct param);
        /// <summary>
        /// 彻底删除套餐产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
    }
}
