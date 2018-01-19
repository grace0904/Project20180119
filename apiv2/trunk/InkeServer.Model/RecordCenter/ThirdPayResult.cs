using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ThirdPayResult
    {
        public string ThirdPay_ID { get; set; }
        public int BusinessClass { get; set; }
        public string Shop_ID { get; set; }
        public string Shop_Name { get; set; }
        public int PayType { get; set; }
        public decimal PayMoney { get; set; }
        public int PayStatus { get; set; }
        public string PayBussinessNum { get; set; }
        
        public DateTime? AddTime { get; set; }
    }
}
