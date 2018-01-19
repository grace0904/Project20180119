using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 积分兑换 结果集
    /// </summary>
    public class IntegralExchangePageResult : IntegralExchangeInfo
    {
        public string Member_Name { get; set; }
        public string Member_Sex { get; set; }
        public string Member_MobilePhone { get; set; }
        public string Shop_Name { get; set; }
        public string Discount_Name { get; set; }
        public string Card_Num { get; set; }
    }
}
