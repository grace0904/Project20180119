using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class SysPowerInfo
    {
        #region Model
        private string _power_id;
        private string _power_code;
        private string _power_name;
        private string _parentcode;
        private int? _level;
        private string _operatebuttonstring;
        /// <summary>
        /// 
        /// </summary>
        public string Power_ID
        {
            set { _power_id = value; }
            get { return _power_id; }
        }
        /// <summary>
        /// 编码(6位) 
        /// </summary>
        public string Power_Code
        {
            set { _power_code = value; }
            get { return _power_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Power_Name
        {
            set { _power_name = value; }
            get { return _power_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentCode
        {
            set { _parentcode = value; }
            get { return _parentcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Level
        {
            set { _level = value; }
            get { return _level; }
        }
        /// <summary>
        /// 菜单操作功能--字符串格式如括号内格式（1-添加|2-修改|3-删除|4-查询|) 备注：数字1为菜单功能ID，‘添加’为功能名称
        /// </summary>
        public string OperateButtonString
        {
            set { _operatebuttonstring = value; }
            get { return _operatebuttonstring; }
        }
        #endregion Model
    }
}
