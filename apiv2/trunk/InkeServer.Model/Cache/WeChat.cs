using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class WeChat
    {
        public string WeChat_ID { get; set; }
        public string Original_ID { get; set; }
        public int? WeChatType { get; set; }
        public string WeChatName { get; set; }
        public string WechatNumber { get; set; }
        public string APPID { get; set; }
        public string AppSecret { get; set; }
        public string Token { get; set; }
        public string EncodingAESKey { get; set; }
        public string Mch_ID { get; set; }
        public string PayKey { get; set; }
        public int Status { get; set; }
        public string Merchant_ID { get; set; }
        public string Shop_ID { get; set; }
        public DateTime? AddTime { get; set; }
        public string Operator { get; set; }
    }
}
