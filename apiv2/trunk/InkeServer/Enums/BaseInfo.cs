using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 基础资料管理列表
    /// </summary>
    public enum BaseInfo : int
    {
        #region
        /// <summary>
        /// 优惠券种类
        /// </summary>
        [Description("优惠券种类")]
        优惠券种类 = 3,
        /// <summary>
        /// 优惠券单位
        /// </summary>
        [Description("优惠券单位")]
        优惠券单位 = 2,
        /// <summary>
        ///产品单位
        /// </summary>
        [Description("产品单位")]
        产品单位 = 4,
        /// <summary>
        /// 模板类型
        /// </summary>
        [Description("模板类型")]
        模板类型 = 6,
        /// <summary>
        /// 积分产品种类
        /// </summary>
        [Description("积分产品种类")]
        积分产品种类 = 1,
       /// <summary>
        /// 产品种类
        /// </summary>
        [Description("产品种类")]
        产品种类 = 5,
        /// <summary>
        /// 座位类型
        /// </summary>
        [Description("座位类型")]
        座位类型 = 7
        #endregion
    }
}
