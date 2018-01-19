using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 店铺员工基础类 
    /// </summary>
    public class EmployeeInfo
    {
        public EmployeeInfo()
        { }
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string Employee_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 工号
        /// </summary>
        public string Employee_Code
        {
            set;
            get;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Employee_Name
        {
            set;
            get;
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Employee_Sex
        {
            set;
            get;
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Employee_birthday
        {
            set;
            get;
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Employee_Tel
        {
            set;
            get;
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Employee_Address
        {
            set;
            get;
        }
        /// <summary>
        /// 照片
        /// </summary>
        public string Employee_Pic
        {
            set;
            get;
        }
        /// <summary>
        /// 基本工资
        /// </summary>
        public decimal? Employee_Salary
        {
            set;
            get;
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 上司
        /// </summary>
        public string Employee_Lead_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OptionTimestamp
        {
            set;
            get;
        }
        #endregion Model
    }
}
