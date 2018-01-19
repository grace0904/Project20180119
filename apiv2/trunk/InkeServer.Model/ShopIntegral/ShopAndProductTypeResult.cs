using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopAndProductTypeResult
    {
        /// <summary>
        /// 店铺信息及其子下的产品类型列表
        /// </summary>
        public List<ShopInfoAndProductTypeList> shopinfoandproducttype = new List<ShopInfoAndProductTypeList>();
        /// <summary>
        /// 可用店铺列表
        /// </summary>
        public string ableShoplist { get; set; }
    }
}
