using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantBaseQueryResult
    {
        /// <summary>
        /// ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string MerchantBaseInfo_Name { get; set; }
        /// <summary>
        /// 基础信息类型
        /// </summary>
        public int BaseInfoClass { get; set; }
    }
}
