using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 商家图片
    /// </summary>
    public class MerchantImg
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public string Img_ID { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string Img_Url { get; set; }
        /// <summary>
        /// 图片分类1 Logo 2 产品图片 3形象图片 4活动图片 5用户头像
        /// </summary>
        public int Img_Type { get; set; }
        /// <summary>
        /// 是否为首页展示
        /// </summary>
        public int Img_IsIndex { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }

    }

}
