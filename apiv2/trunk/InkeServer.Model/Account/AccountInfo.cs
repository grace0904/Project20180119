using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    ///  账号信息基础类 
    /// </summary>
    [Serializable]
    public class AccountInfo
    {
        #region
        public string Account_ID { get; set; }
        public string Account_Login { get; set; }
        public string Account_Password { get; set; }
        public string Account_Memo { get; set; }
        public int? Account_Status { get; set; }
        public int? Account_LoginPOS { get; set; }
        public int? Account_LoginKFT { get; set; }
        public int? Account_LoginCRM { get; set; }
        public string Employee_ID { get; set; }
        public string Position_ID { get; set; }
        public string Merchant_ID { get; set; }
        public string UsableShopList { get; set; }
        public string Operator { get; set; }
        public string Shop_ID { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? OperationTime { get; set; }
        public DateTime OptionTimestamp { get; set; }
        #endregion
    }
}
