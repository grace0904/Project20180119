using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopInfoAndProductTypeList
    {
        /// <summary>
        /// 店铺信息及店铺下的产品类型集合
        /// </summary>
        public List<MerchantBaseInfoIDAndName> MerBaseInfoList = new List<MerchantBaseInfoIDAndName>();
        public string Shop_ID { get; set; }
        public string Shop_Name { get; set; }
    }
}
