using InkeServer.DataMapping;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using InkeServer.Enums;
using System.Data.Entity.SqlServer;
using Inke.Common.Exceptions;
using AutoMapper;
using Inke.Common.Paginations;
namespace InkeServer.Service.Impl
{
    public class ConsumeRecordService : ServiceBase, IConsumeRecordService
    {
        //标记为注入对象
        [InjectionConstructor]
        public ConsumeRecordService() { }
        [Dependency]
        public IOrderService OrderService { get; set; }
        /// <summary>
        /// 获得查询消费记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<ConsumeRecordInfo> GetConsumeRecordList(ConsumeRecordRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            int type = (int)OrderProcess.Completed;
            int paytype1 = (int)PayType.Cash;
            int paytype2 = (int)PayType.BankCard;
            int paytype3 = (int)PayType.MemberCard;
            int paytype4 = (int)PayType.AliPay;
            int paytype5 = (int)PayType.WeiXin;
            int paytype6 = (int)PayType.Groupbuy;
            var list = (from a in Entities.Bus_Orders
                        join b in Entities.Bas_Member on a.Member_ID equals b.Member_ID into ab
                        from ab1 in ab.DefaultIfEmpty()
                        join c in Entities.Bas_Card on a.Card_ID equals c.Card_ID into ac
                        from ac1 in ac.DefaultIfEmpty()
                        join d in Entities.Bas_Shop on a.Shop_ID equals d.Shop_ID into ad
                        from ad1 in ad.DefaultIfEmpty()
                        join e in Entities.Bas_ShopSeat on a.Seat_ID equals e.Seat_ID into ae
                        from ae1 in ae.DefaultIfEmpty()
                        join f in Entities.Bas_CardDiscountType on ac1.Discount_ID equals f.Discount_ID into cf
                        from cf1 in cf.DefaultIfEmpty()
                        where a.Order_Process == type && a.Merchant_ID == param.Merchant_ID && a.Adjust == param.IsAdjust
                        select new ConsumeRecordInfo
                        {
                            #region 赋值
                            Order_ID = a.Order_ID,
                            Order_Class = a.Order_Class,
                            Business_Num = a.Business_Num,
                            Card_ID = a.Card_ID,
                            Card_Num = ac1 == null ? "" : ac1.Card_Num,
                            Card_BusinessID = a.Card_BusinessID,
                            Discount_Name = cf1 == null ? "" : cf1.Discount_Name,
                            Member_MobilePhone = ab1 == null ? "" : ab1.Member_MobilePhone,
                            Member_ID = a.Member_ID,
                            Member_Name = ab1.Member_Name,
                            Discount = a.Discount,
                            ConsumeMoney = a.ConsumeMoney,
                            DiscountMoney = a.DiscountMoney,
                            CouponMoney = a.CouponMoney,
                            IntegralMoney = a.IntegralMoney,
                            ReduceMantissaMoney = a.ReduceMantissaMoney,
                            FinalMoney = a.FinalMoney,
                            ActualIncomeMoney = a.ActualIncomeMoney,
                            Order_GetIntegral = a.Order_GetIntegral,
                            CashPay = (from t in Entities.Bus_OrderPay where t.Order_ID == a.Order_ID select t).Sum(t => ((t == null || t.PayType != paytype1) ? 0 : t.PayMoney)),
                            BankCardPay = (from t in Entities.Bus_OrderPay where t.Order_ID == a.Order_ID select t).Sum(t => ((t == null || t.PayType != paytype2) ? 0 : t.PayMoney)),
                            MemberCardPay = (from t in Entities.Bus_OrderPay where t.Order_ID == a.Order_ID select t).Sum(t => ((t == null || t.PayType != paytype3) ? 0 : t.PayMoney)),
                            AliPayPay = (from t in Entities.Bus_OrderPay where t.Order_ID == a.Order_ID select t).Sum(t => ((t == null || t.PayType != paytype4) ? 0 : t.PayMoney)),
                            WeiXinPay = (from t in Entities.Bus_OrderPay where t.Order_ID == a.Order_ID select t).Sum(t => ((t == null || t.PayType != paytype5) ? 0 : t.PayMoney)),
                            GroupbuyPay = (from t in Entities.Bus_OrderPay where t.Order_ID == a.Order_ID select t).Sum(t => ((t == null || t.PayType != paytype6) ? 0 : t.PayMoney)),
                            GuaZhangMoney = a.GuaZhangMoney,
                            Seat_Name = ae1 == null ? "" : ae1.Seat_Name,
                            Order_People = a.Order_People,
                            Memo = a.Memo,
                            Operator = a.Operator,                            
                            Terminal = a.Terminal,
                            Shop_ID = a.Shop_ID,
                            Shop_Name = ad1 == null ? "" : ad1.Shop_Name,
                            Adjust = a.Adjust,
                            FinalTime = a.FinalTime,
                            OpenSeatTime = a.OpenSeatTime,
                            OperationTime = a.OperationTime,
                            #endregion

                        });
            #region 构造查询条件
            list = list.WhereIf(a => a.Order_ID == param.Order_ID, param.Order_ID.NotNullOrEmpty());

            if (!string.IsNullOrEmpty(param.ShopGroup))
            {
                var arry = param.ShopGroup.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                list = list.WhereIf(a => param.ShopGroup.Contains(a.Shop_ID), arry != null && arry.Length > 0);
            }

            list = list.WhereIf(a => a.Business_Num == param.Business_Num, param.Business_Num.NotNullOrEmpty());
            list = list.WhereIf(a => a.Member_ID == param.Member_ID, param.Member_ID.NotNullOrEmpty());
            if (!string.IsNullOrEmpty(param.Card_Num))
            {
                var card_BusinessID = (from c in Entities.Bas_Card where c.Merchant_ID == param.Merchant_ID && c.Card_Num == param.Card_Num select c.Card_BusinessID).FirstOrDefault();
                list = list.WhereIf(a => a.Card_BusinessID == card_BusinessID, card_BusinessID.NotNullOrEmpty());
            }
            list = list.WhereIf(a => a.Member_MobilePhone == param.MobilePhone, param.MobilePhone.NotNullOrEmpty());
            list = list.WhereIf(a => param.Member_Name.IndexOf(a.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            list = list.WhereIf(a => a.ConsumeMoney >= param.MoneyForm && a.ConsumeMoney <= param.MoneyTo, !string.IsNullOrEmpty(param.MoneyForm.ToString()) && !string.IsNullOrEmpty(param.MoneyTo.ToString()));
            list = list.WhereIf(a => a.OpenSeatTime >= param.DateForm && a.OpenSeatTime <= param.DateTo, !string.IsNullOrEmpty(param.DateForm.ToString()) && !string.IsNullOrEmpty(param.DateTo.ToString()));
            #endregion

            KeySelectors<ConsumeRecordInfo, DefaultSortBy> _keySelectors =
           new KeySelectors<ConsumeRecordInfo, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.OperationTime);

            return QueryPaginate<ConsumeRecordInfo, ConsumeRecordInfo>(list, param, _keySelectors);
        }
        /// <summary>
        ///获得消费记录详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ConsumeRecordInfoResult GetConsumeRecordInfo(ConsumeRecordInfoRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            ConsumeRecordInfoResult data = new ConsumeRecordInfoResult();
            #region 得到订单以及历史订单
            //得到订单
            if (!Entities.Bus_Orders.Any(a => a.Order_ID == param.Order_ID))
                throw new BusinessException(ResultCode.DataNotFound.Name());
            var query = (from a in Entities.Bus_Orders
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
                         });
            var info = query.Where(a => a.OrderInfo.Order_ID == param.Order_ID).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            OrderInfo result = info.MapTo<OrderInfo>();
            result.Order = info.OrderInfo.MapTo<Order>();
            data.OrderInfo = result;
            var orderinfo = result.Order;
            if (orderinfo == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());

            if (param.Adjust == 0)
            {
                //消费调整记录 ,查询历史订单
                var historylist = query.Where(a => a.OrderInfo.Merchant_ID == param.Merchant_ID && a.OrderInfo.Shop_ID == param.Shop_ID && a.OrderInfo.Business_Num == orderinfo.Business_Num && a.OrderInfo.Adjust == 1);
                List<OrderInfo> list = new List<OrderInfo>();
                historylist.ForEach(p =>
                {
                    var t = p.MapTo<OrderInfo>();
                    t.Order = p.OrderInfo.MapTo<Order>();
                    list.Add(t);
                });
                data.HistoryOrderInfo = list;
            }

            #endregion
            #region 查询支付方式
            //查询支付方式
            var orderpay = (from o in Entities.Bus_OrderPay where o.Order_ID == orderinfo.Order_ID select o);
            data.OrderPay = orderpay.MapTo<OrderPay>();
            #endregion
            #region 查询优惠券
            //查询优惠券
            int businessClass = (int)BusinessClass.AutoPromotion;
            var cardcoupons = (from c in Entities.Bus_CardCoupon
                               join cd in Entities.Bas_Coupon on c.Coupon_ID equals cd.Coupon_ID into cd1
                               from d in cd1.DefaultIfEmpty()
                               join cm in Entities.Bas_MerchantBaseInfo on d.MerchantBaseInfo_ID equals cm.MerchantBaseInfo_ID into cm1
                               from m in cm1.DefaultIfEmpty()
                               where c.Adjust == 0 && c.Merchant_ID == orderinfo.Merchant_ID && m.Del != 1
                               && c.Card_BusinessID == orderinfo.Card_BusinessID
                               && c.Status == 1 && c.Order_ID == orderinfo.Order_ID
                                   && !((from t in Entities.Bus_CardCoupon where t.BusinessClass == businessClass && c.Record_ID == orderinfo.Order_ID select c.CardCoupon_ID).Contains(c.CardCoupon_ID))
                               select new CardCouponInfo
                               {
                                   CardCoupon_ID = c.CardCoupon_ID,
                                   Coupon_ID = c.Coupon_ID,
                                   Coupon_Name = c.Coupon_Name,
                                   Status = c.Status,
                                   FDate = c.FDate,
                                   LDate = c.LDate,
                                   Coupon_Code = d == null ? "" : d.Coupon_Code,
                                   Coupon_Class = d == null ? 0 : d.Coupon_Class,
                                   Product_ID = d == null ? "" : d.Product_ID,
                                   Coupon_ConsumeClass = d == null ? 0 : d.Coupon_ConsumeClass,
                                   Coupon_Cash = d == null ? 0 : d.Coupon_Cash,
                                   Coupon_UserNum = d == null ? 0 : d.Coupon_UserNum,
                                   Coupon_Unit = d == null ? "" : d.Coupon_Unit,
                                   Coupon_DeductionPrice = d == null ? 0 : d.Coupon_DeductionPrice,
                                   Coupon_Integral = d == null ? 0 : d.Coupon_Integral,
                                   MerchantBaseInfo_ID = d == null ? "" : d.MerchantBaseInfo_ID,
                                   MerchantBaseInfo_Name = d == null ? "" : (m == null ? "" : m.MerchantBaseInfo_Name)
                               });
            //此处修改v1版本查询逻辑（(c.Status == 0 || c.Order_ID == orderinfo.Order_ID)-> c.Status == 1 && c.Order_ID == orderinfo.Order_ID）

            data.CardCoupon = cardcoupons.ToList();
            #endregion
            #region 查询订单消费产品列表
            if (param.Adjust == 0)
            {
                //查询订单消费产品列表
                var orderbasket = (from b in Entities.Bus_OrderBasket
                                   join sp in Entities.Bas_ShopProducts on b.ShopProduct_ID equals sp.ShopProduct_ID into sp1
                                   from s in sp1.DefaultIfEmpty()
                                   where b.Order_ID == orderinfo.Order_ID && b.Merchant_ID == orderinfo.Merchant_ID && b.Shop_ID == orderinfo.Shop_ID && b.Del != 1 && b.Adjust == 0
                                   select new
                                   {
                                       Name = s == null ? "" : s.Name,
                                       Discount = s == null ? 0 : s.Discount,
                                       IsCombo = s == null ? 0 : s.Combo,
                                       OrderBasketinfo = b
                                   });
                List<OrderBasketInfo> list = new List<OrderBasketInfo>();
                orderbasket.ForEach(b =>
                {
                    //设置时间戳为null
                    b.OrderBasketinfo.OptionTimestamp = null;
                    var t = b.MapTo<OrderBasketInfo>();
                    t.OrderBasket = b.OrderBasketinfo.MapTo<OrderBasket>();
                    list.Add(t);
                });
                data.OrderBasketInfo = list;
            }

            #endregion
            #region 短信
            // 查询短信 
            //int smstype = (int)SmsTemplate.ConsumptionAdjustment;
            //var sms = (from s in Entities.Sys_SmsTemplate
            //           join sb in Entities.Bas_SmsTemplateCustom on s.SmsTemplate_ID equals sb.SmsTemplate_ID into sb1
            //           from b in sb1.DefaultIfEmpty()
            //           where s.SmsType == smstype && b.Merchant_ID == param.Merchant_ID
            //           select new SmsSendCustom
            //           {
            //               Send=b==null?0:b.Custom_Send,
            //               SmsContent = s.SmsTemplate_Content,
            //               SmsType = s.SmsType
            //           }).FirstOrDefault();
            //data.Sms = sms.MapTo<SmsSendCustom>();
            #endregion

            return data;
        }

    }
}
