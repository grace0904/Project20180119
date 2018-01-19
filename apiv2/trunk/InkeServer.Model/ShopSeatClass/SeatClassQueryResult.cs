﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class SeatClassQueryResult
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ShopSeatClass_ID { get; set; }
        /// <summary>
        /// 座位类型名称
        /// </summary>
        public string ShopSeatClass_Name { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
    }
}
