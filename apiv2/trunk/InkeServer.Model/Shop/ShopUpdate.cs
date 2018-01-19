using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopUpdate : BaseRequest
    {
        #region Model

        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Shop_ID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        [DisplayName("店铺名称")]
        public string Shop_Name { get; set; }
        /// <summary>
        /// 店铺联系电话
        /// </summary>
        [DisplayName("店铺联系电话")]
        public string Shop_Tel { get; set; }
        /// <summary>
        /// 店铺联系人
        /// </summary>
        [DisplayName("店铺联系人")]
        public string Shop_LinkMan { get; set; }
        /// <summary>
        /// 省份ID
        /// </summary>
        [DisplayName("省份ID")]
        public string Prov_ID { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        [DisplayName("城市ID")]
        public string City_ID { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        [DisplayName("区域ID")]
        public string Area_ID { get; set; }
        /// <summary>
        /// 店铺地址
        /// </summary>
        [DisplayName("店铺地址")]
        public string Shop_Address { get; set; }
        /// <summary>
        /// 所属商圈
        /// </summary>
        [DisplayName("所属商圈")]
        public string CommerceGroup_ID { get; set; }
        /// <summary>
        /// 店铺重置密码
        /// </summary>
        [DisplayName("店铺重置密码")]
        public string Shop_RechargePassword { get; set; }
        /// <summary>
        /// 开通时间
        /// </summary>
        [DisplayName("开通时间")]
        public DateTime Shop_OpenDate { get; set; }
        /// <summary>
        /// 停止时间
        /// </summary>
        [DisplayName("停止时间")]
        public DateTime Shop_EndDate { get; set; }
        /// <summary>
        /// 短信
        /// </summary>
        [DisplayName("短信")]
        public int Shop_SmsCount { get; set; }
        /// <summary>
        /// 店铺Logo
        /// </summary>
        [DisplayName("店铺Logo")]
        public string Shop_Logo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_BusinessTime { get; set; }
        /// <summary>
        /// 0 关闭 1 启用
        /// </summary>
        [DisplayName("店铺是否启用状态")]
        public int Shop_Status { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
       
        /// <summary>
        /// 起送价
        /// </summary>
        [DisplayName("起送价")]
        public decimal Deliveryamount { get; set; }
        /// <summary>
        /// 配送费
        /// </summary>
        [DisplayName("配送费")]
        public decimal Takeoutcost { get; set; }
        /// <summary>
        /// 外卖开始时间
        /// </summary>
        [DisplayName("外卖开始时间")]
        public string TakeOutTimeBegin { get; set; }
        /// <summary>
        /// 外卖结束时间
        /// </summary>
        [DisplayName("外卖结束时间")]
        public string TakeOutTimeEnd { get; set; }
        /// <summary>
        /// 是否启用外卖 0 否 1 是
        /// </summary>
        [DisplayName("是否启用外卖")]
        public bool TakeOutStatus { get; set; }
        #endregion Model
    }
}
