using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IOrderService
    {
        /// <summary>
        /// 根据订单ID获取订单详细信息 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        OrderInfo GetOrderInfo(string orderId);
    }
}
