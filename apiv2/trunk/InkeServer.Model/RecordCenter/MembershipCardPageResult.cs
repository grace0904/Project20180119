using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员卡记录 结果集
    /// </summary>
    public class MembershipCardPageResult : MembershipCardInfo
    {
        public string Member_Name { get; set; }
        public string Member_Sex { get; set; }
        public string Member_MobilePhone { get; set; }
        public string Shop_Name { get; set; }
    }
}
