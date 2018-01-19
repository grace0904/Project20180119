using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 添加/修改 店铺员工请求类
    /// </summary>
    public class EmployeeAddOrUpdateRequest : BaseRequest
    {
        /// <summary>
        ///  员工ID
        /// </summary>
        [DisplayName("员工ID")]
        public string Employee_ID { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        [DisplayName("工号")]
        public string Employee_Code { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        [DisplayName("员工名称")]
        public string Employee_Name { get; set; }
        /// <summary>
        /// 员工性别
        /// </summary>
        [DisplayName("员工性别")]
        public string Employee_Sex { get; set; }
        /// <summary>
        /// 员工生日
        /// </summary>
        [DisplayName("员工生日")]
        public DateTime? Employee_birthday { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName("联系电话")]
        public string Employee_Tel { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [DisplayName("地址")]
        public string Employee_Address { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        [DisplayName("照片")]
        public string Employee_Pic { get; set; }
        /// <summary>
        /// 基本工资
        /// </summary>
        [DisplayName("基本工资")]
        public decimal? Employee_Salary { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        [DisplayName("职位")]
        public string Position_ID { get; set; }
        /// <summary>
        /// 上司
        /// </summary>
        [DisplayName("上司")]
        public string Employee_Lead_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Shop_ID { get; set; }
        /// <summary>
        ///操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
        /// <summary>
        ///备注
        /// </summary>
        [DisplayName("备注")]
        public string Memo { get; set; }
    }
}
