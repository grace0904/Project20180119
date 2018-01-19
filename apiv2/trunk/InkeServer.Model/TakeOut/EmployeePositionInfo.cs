using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 职员信息
    /// </summary>
    public class EmployeePositionInfo
    { 
        /// <summary>
        /// 员工ID
        /// </summary>
        public string Employee_ID { get; set; }
        /// <summary>
        /// 职位ID
        /// </summary>
        public string Position_ID { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string Employee_Name { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Employee_Tel { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string Position_Name { get; set; }
    }
}
