using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
   public   class ProComboListAndMerComboListData
    {
        /// <summary>
        /// 套餐产品的套餐分组ID和名称
        /// </summary>
       public List<ComboGroupIDAndName> ProductComboIDAndNameList = new List<ComboGroupIDAndName>();
        /// <summary>
        /// 商家套餐分组ID和名称
        /// </summary>
       public List<ComboGroupIDAndName> MerchantComboIDAndNameList = new List<ComboGroupIDAndName>();
    }
}
