using Inke.Common.Exceptions;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace InkeServer.Service.Impl
{
    public class OrderService : ServiceBase, IOrderService
    {
        //标记为注入对象
        [InjectionConstructor]
        public OrderService() { }
        /// <summary>
        /// 根据订单ID获取订单详细信息 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderInfo GetOrderInfo(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
                throw new BusinessException(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bus_Orders
                        join ac in Entities.Bas_Card on a.Card_ID equals ac.Card_ID into ac1
                        from c in ac1.DefaultIfEmpty()
                        join ab in Entities.Bas_Member on a.Member_ID equals ab.Member_ID into ab1
                        from b in ab1.DefaultIfEmpty()
                        join bd in Entities.Bas_CardDiscountType on c.Discount_ID equals bd.Discount_ID into bd1
                        from d in bd1.DefaultIfEmpty()
                        join sa in Entities.Bas_Shop on a.Shop_ID equals sa.Shop_ID into sa1
                        from s in sa1.DefaultIfEmpty()
                        join ssa in Entities.Bas_ShopSeat on a.Seat_ID equals ssa.Seat_ID into ssa1
                        from ss in ssa1.DefaultIfEmpty()
                        where a.Order_ID == orderId
                        select new
                        {
                            OrderInfo = a,
                            Card_Num = c == null ? "" : c.Card_Num,
                            Member_Name = b == null ? "" : b.Member_Name,
                            Member_Sex = b == null ? "" : b.Member_Sex,
                            Member_MobilePhone = b == null ? "" : b.Member_MobilePhone,
                            Discount_Name = d == null ? "" : d.Discount_Name,
                            Shop_Name = s == null ? "" : s.Shop_Name,
                            Seat_Name = ss == null ? "" : ss.Seat_Name
                        }).FirstOrDefault();
            if (info != null)
            {
                OrderInfo result = info.MapTo<OrderInfo>();
                result.Order = info.OrderInfo.MapTo<Order>();
                return result;
            }
            return null;
        }
    }
}
