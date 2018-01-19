using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 商家图片分类枚举
    /// </summary>
    public enum MerchantImgType : int
    {
        /// <summary>
        /// 商家Logo
        /// </summary>
        Logo = 1,
        /// <summary>
        /// 产品图片
        /// </summary>
        Product = 2,
        /// <summary>
        /// 形象图片
        /// </summary>
        Image = 3,
        /// <summary>
        /// 活动图片
        /// </summary>
        Activity = 4,
        /// <summary>
        /// 用户头像
        /// </summary>
        User = 5
    }
}
