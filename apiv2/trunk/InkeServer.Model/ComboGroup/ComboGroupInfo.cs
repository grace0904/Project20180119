using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 套餐组基础类
    /// </summary>
    [Serializable]
    public class ComboGroupInfo
    {
        public ComboGroupInfo()
        { }
        #region Model

        /// <summary>
        /// ID
        /// </summary>
        public string ComboGroup_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 组别名称
        /// </summary>
        public string Group_Name
        {
            set;
            get;
        }
        /// <summary>
        /// 最多选择数
        /// </summary>
        public int MaxNum
        {
            set;
            get;
        }
        /// <summary>
        /// 最少选择数
        /// </summary>
        public int MinNum
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

        #endregion Model
    }
}
