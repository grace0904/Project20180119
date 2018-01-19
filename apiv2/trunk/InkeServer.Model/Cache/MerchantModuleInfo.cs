using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantModuleInfo
    {
        public string MerchantModule_ID { get; set; }
        public string Merchant_ID { get; set; }
        public string Module_ID { get; set; }
        public string Module_Code { get; set; }
        public string Module_Name { get; set; }
        public int Status { get; set; }
        public string Module_Perent { get; set; }
    }
}
