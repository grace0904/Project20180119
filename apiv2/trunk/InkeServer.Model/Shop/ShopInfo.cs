using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopInfo
    {
        #region Model

        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 店铺联系电话
        /// </summary>
        public string Shop_Tel { get; set; }
        /// <summary>
        /// 店铺联系人
        /// </summary>
        public string Shop_LinkMan { get; set; }
        /// <summary>
        /// 省份ID
        /// </summary>
        public string Prov_ID { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        public string City_ID { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public string Area_ID { get; set; }
        /// <summary>
        /// 店铺地址
        /// </summary>
        public string Shop_Address { get; set; }
        /// <summary>
        /// 所属商圈
        /// </summary>
        public string CommerceGroup_ID { get; set; }
        /// <summary>
        /// 店铺重置密码
        /// </summary>
        public string Shop_RechargePassword { get; set; }
        /// <summary>
        /// 开通时间
        /// </summary>
        public DateTime Shop_OpenDate { get; set; }
        /// <summary>
        /// 停止时间
        /// </summary>
        public DateTime Shop_EndDate { get; set; }
        /// <summary>
        /// 短信
        /// </summary>
        public int Shop_SmsCount { get; set; }
        /// <summary>
        /// 店铺logo
        /// </summary>
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
        /// 店铺营业时间
        /// </summary>
        public string Shop_BusinessTime { get; set; }
        /// <summary>
        /// 0 关闭 1 启用
        /// </summary>
        public int Shop_Status { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public byte[] OptionTimestamp { get; set; }
        /// <summary>
        /// 起送价
        /// </summary>
        public decimal Deliveryamount { get; set; }
        /// <summary>
        /// 配送费
        /// </summary>
        public decimal Takeoutcost { get; set; }
        /// <summary>
        /// 外卖开始时间
        /// </summary>
        public string TakeOutTimeBegin { get; set; }
        /// <summary>
        /// 外卖结束时间
        /// </summary>
        public string TakeOutTimeEnd { get; set; }
        /// <summary>
        /// 是否启用外卖 0 否 1 是
        /// </summary>
        public bool TakeOutStatus { get; set; }
        #endregion Model
    }
}
