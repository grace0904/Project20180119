using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    ///营销分析详细信息返回类
    /// </summary>
    public  class MarketAnalysisInfoResult
    {
        //已选择店铺数据
        public List<ShopIdAndName> UserShopList { get; set; }
        //消费产品
        public List<MerchantProductIDAndName> ConsumeProductList { get; set; }
        //消费优惠券
        public List<CouponIDAndName> ConsumeCouponList { get; set; }
        //赠送优惠券
        public List<GivenCouponInfo> CouponList { get; set; }
        //基础数据
        public MarketAnalysis MarketAnalysis { get; set; }
    }
}
