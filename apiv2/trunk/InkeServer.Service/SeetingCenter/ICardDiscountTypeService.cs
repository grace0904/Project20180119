using Inke.Common.Paginations;
using InkeServer.Model;
using System.Collections.Generic;

namespace InkeServer.Service
{
    public interface ICardDiscountTypeService
    {
        /// <summary>
        /// 分页查询 会员卡折扣类型集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<CardDiscountTypeInfo> Query(MerchantIdPageRequest param);
        /// <summary>
        /// 新增会员卡折扣类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(CardDiscountTypeAddOrUpdate param);
        /// <summary>
        /// 修改会员卡折扣类型信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Update(CardDiscountTypeAddOrUpdate param);
        /// <summary>
        /// 将会员卡折扣类型标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 获取会员卡折扣类型详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>  
        CardDiscountTypeInfo GetInfo(RecordIDRequest param);
        /// <summary>
        /// 获取会员卡折扣类型列表集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>  
        List<CardDiscountTypeInfo> GetList(MerchantIdRequest param);
    }
}
