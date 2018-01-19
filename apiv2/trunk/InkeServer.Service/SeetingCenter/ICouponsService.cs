using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface ICouponsService
    {
        /// <summary>
        /// 分页查询 优惠券集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<CouponInfoResult> Query(CouponsQueryRequest param);
        /// <summary>
        /// 将优惠券标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>  
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 新增优惠券
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(AddOrUpdateCouponsRequest param);
        /// <summary>
        /// 修改优惠券信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>  
        bool Update(AddOrUpdateCouponsRequest param);
        /// <summary>
        /// 获取优惠券详细 信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>  
        CouponInfoResult GetInfo(RecordIDRequest param);
        /// <summary>
        /// 获取商家所有优惠券列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<CouponInfo> GetCouponList(MerchantIdRequest param);
        /// <summary>
        /// 分页获取可用优惠券列表（排除已停用和已过期的）
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<CouponInfoResult> GetAvailableCouponList(AvailableCouponQueryRequest param);
    }
}
