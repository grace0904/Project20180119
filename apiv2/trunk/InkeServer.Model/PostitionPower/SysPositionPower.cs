using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class SysPositionPower
    {
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public string Power_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 编码(6位) 
        /// </summary>
        public string Power_Code
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Power_Name
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentCode
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Level
        {
            get;
            set;
        }
        /// <summary>
        /// 菜单操作功能--字符串格式如括号内格式（1-添加|2-修改|3-删除|4-查询|) 备注：数字1为菜单功能ID，‘添加’为功能名称
        /// </summary>
        public string OperateButtonString
        {
            get;
            set;
        }
        #endregion Model
    }
}
