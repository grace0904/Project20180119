using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
   public class LoginResult
   {
       #region
       /// <summary>
       /// 账号ID
       /// </summary>
       public string Account_ID { get; set; }
       /// <summary>
       /// 登录帐号
       /// </summary>
       public string Account_Login { get; set; }
       /// <summary>
       /// 人员ID
       /// </summary>
       public string Employee_ID { get; set; }
       /// <summary>
       ///职位ID
       /// </summary>
       public string Position_ID { get; set; }
       /// <summary>
       /// 商家ID
       /// </summary>
       public string Merchant_ID { get; set; }
       /// <summary>
       /// 可用店铺
       /// </summary>
       public string UsableShopList { get; set; }
       /// <summary>
       /// 店铺ID
       /// </summary>
       public string Shop_ID { get; set; }
       #endregion
       /// <summary>
       /// 商家名称
       /// </summary>
       public string Merchant_Name { get; set; }
       /// <summary>
       /// 商家简名
       /// </summary>
       public string Merchant_ShortName { get; set; }
       /// <summary>
       /// 店铺名称
       /// </summary>
       public string Shop_Name { get; set; }
       /// <summary>
       /// 登录名称
       /// </summary>
       public string Employee_Name { get; set; }
       /// <summary>
       /// 职位名称
       /// </summary>
       public string Position_Name { get; set; }
    }
}
