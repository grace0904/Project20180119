using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 获取商家图片列表 请求类 
    /// </summary>
    public  class MerchantImgListRequest:BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 图片分类 0-全部，1 Logo 2 产品图片 3形象图片 4活动图片 5用户头像
        /// </summary>
        public int Img_Type { get; set; }
    }
}
