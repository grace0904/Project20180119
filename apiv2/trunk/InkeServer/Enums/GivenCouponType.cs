using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 赠送优惠券业务类型
    /// </summary>
    public enum GivenCouponType : int
    {
        AutoPromotion = 1,  //自动促销
        AutoPromotionExe = 2, //自动促销发放
        MarketingAnalyze = 3,//营销分析
        MarketingAnalyzeExe = 4 //营销分析发放

    }
}
