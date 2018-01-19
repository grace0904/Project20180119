using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    /// <summary>
    /// 优惠券记录
    /// </summary>
    public interface ICouponRechargeSercice
    {
        /// <summary>
        /// 分页查询优惠券记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<CouponRechargePageResult> GetCouponRechargeListPage(CouponRechargePageRequest param);
        /// <summary>
        /// 根据ID及商家ID获取优惠券信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<CouponRechargeRecordInfoResult> GetCouponRechargeRecordbyID(CouponRechargeRecordInfoRequest param);
    }
}
