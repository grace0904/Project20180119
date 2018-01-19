using InkeServer.DataMapping;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InkeServer.Enums;
using Inke.Common.Extentions;
using Inke.Common.Exceptions;
using Inke.Common.Helpers;

namespace InkeServer.Service.Impl
{
    /// <summary>
    ///  老板手机报表服务类 
    /// </summary>
    public class BossPhoneService : ServiceBase, IBossPhoneService
    {
        /// <summary>
        /// 获取老板手机报表列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<BossReportRecordResult> GetBossReportRecord(MerchantIdRequest param)
        {
            List<BossReportRecordResult> result = new List<BossReportRecordResult>();
            result = (from l in Entities.Bas_BossReport
                      where l.Merchant_ID == param.Merchant_ID && l.Del != 1
                      select new
                      {
                          BossReport_ID = l.BossReport_ID,
                          BossReportName = l.BossReportName,
                          SendTime = l.SendTime,
                          Status = l.Status,
                          ReceiveMobilePhone = l.ReceiveMobilePhone,
                          OperationTime = l.OperationTime,
                          Operator = l.Operator,
                          Memo = l.Memo,
                          ShopList=l.ShopList,
                          ShopNames = (from k in Entities.Bas_Shop
                                       where l.ShopList.Contains(k.Shop_ID)
                                       select k.Shop_Name)
                      }).AsEnumerable().Select(l => new
                      {
                          BossReport_ID = l.BossReport_ID,
                          BossReportName = l.BossReportName,
                          SendTime = l.SendTime,
                          Status = l.Status,
                          ReceiveMobilePhone = l.ReceiveMobilePhone,
                          OperationTime = l.OperationTime,
                          Operator = l.Operator,
                          ShopList = l.ShopList,
                          Memo = l.Memo,
                          ShopNames = string.Join(",", l.ShopNames.ToArray())
                      }).ToList().MapTo<BossReportRecordResult>();
            return result;
        }
        /// <summary>
        /// 新增老板报表
        /// </summary>
        /// <param name="param"></param>
        public void Insert(BossPhoneInsert param)
        {
            #region Insert
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //检查当前报表名称是否在该商家中存在
            var temp = (from m in Entities.Bas_BossReport
                        where m.Merchant_ID == param.Merchant_ID && m.Del != 1 && m.BossReportName == param.BossReportName
                        select m).FirstOrDefault();

            temp.MustIsNull(ResultCode.DataRepeated.Name());

            var bossphoneinfo = param.MapTo<Bas_BossReport>();
            bossphoneinfo.BossReport_ID = Inke.Common.Helpers.GUID.CreateGUID();
            bossphoneinfo.Del = 0;
            bossphoneinfo.AddTime = DateTime.Now;
            bossphoneinfo.OperationTime = DateTime.Now;

            if (!Insert(bossphoneinfo))
                throw new BusinessException(ResultCode.AddFaild.Name());

            #endregion
        }
        /// <summary>
        /// 修改老板报表信息
        /// </summary>
        /// <param name="param"></param>
        public void Update(BossPhoneUpdate param)
        {
            #region Update
            var temp = (from m in Entities.Bas_BossReport
                        where m.BossReport_ID == param.BossReport_ID && m.Del != 1
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            temp.ShopList = param.ShopList;
            temp.BossReportName = param.BossReportName;
            temp.SendTime = param.SendTime;
            temp.Status = param.Status;
            temp.ReceiveMobilePhone = param.ReceiveMobilePhone;
            temp.Memo = param.Memo;
            temp.OperationTime = DateTime.Now;
            temp.BusinessBeginHour = param.BusinessBeginHour;
            temp.BusinessBeginMinute = param.BusinessBeginMinute;
            temp.BusinessDate = param.BusinessDate;
            temp.BusinessEndMinute = param.BusinessEndMinute;
            temp.BusinessEndHour = param.BusinessEndHour;
            temp.SendCycle = param.SendCycle;
            temp.MemberIncrease = param.MemberIncrease;
            temp.CardIncrease = param.CardIncrease;
            temp.ConsumeTotal = param.ConsumeTotal;
            temp.MemberConsumeTotal = param.MemberConsumeTotal;
            temp.MemberRechargeTotal = param.MemberRechargeTotal;
            temp.IndividualConsumeTotal = param.IndividualConsumeTotal;
            temp.CouponRechargeQuantity = param.CouponRechargeQuantity;
            temp.CouponUseQuantity = param.CouponUseQuantity;
            temp.MemberAddIntegral = param.MemberAddIntegral;
            temp.MemberReductionIntegral = param.MemberReductionIntegral;
            temp.MemberMoneyTotal = param.MemberMoneyTotal;
            temp.MemberIntegralTotal = param.MemberIntegralTotal;
            temp.Merchant_ID = param.Merchant_ID;
            temp.Operator = param.Operator;
            temp.Del = 0;

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }
        /// <summary>
        /// 删除老板报表信息
        /// </summary>
        /// <param name="param"></param>
        public void Delete(OperationBaseRequest param)
        {
            if (param.Record_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.ArgumentsMiss.Name());
            #region Delete

            var temp = (from m in Entities.Bas_BossReport
                        where m.Del != 1 && m.BossReport_ID == param.Record_ID
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            temp.Del = 1;
            bool state = Entities.SaveChanges() > 0;
            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

        public BossReportRecordInfoResult GetBossReportInfo(string id)
        {
            #region Query
            BossReportRecordInfoResult result = new BossReportRecordInfoResult();

            id.MustNotNull(ResultCode.ArgumentsMiss.Name());

            result = (from s in Entities.Bas_BossReport
                      where s.Del != 1 && s.BossReport_ID == id
                      select s).FirstOrDefault().MapTo<BossReportRecordInfoResult>();
            return result;
            #endregion
        }
    }
}
