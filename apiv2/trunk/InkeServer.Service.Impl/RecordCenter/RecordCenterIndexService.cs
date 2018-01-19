using AutoMapper;
using Inke.Common.Exceptions;
using Inke.Common.Extentions;
using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using InkeServer.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Inke.Common.Helpers;

namespace InkeServer.Service.Impl
{
    public class RecordCenterIndexService : ServiceBase, IRecordCenterIndexService
    {
        //标记为注入对象
        [InjectionConstructor]
        public RecordCenterIndexService() { }

        /// <summary>
        /// 获取记录中心首页相关信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RecordCenterIndexResult GetRecordCenterIndexInfo(RecordCenterIndexRequest param)
        {
            RecordCenterIndexResult center = new RecordCenterIndexResult();

            Entities e = new Entities();
            SqlParameter[] para = new SqlParameter[] {
              new SqlParameter("@merchantid",param.Merchant_ID),
              new SqlParameter("@shopids",param.Shop_ID),
              new SqlParameter("@begintime",param.Begin_Time),
              new SqlParameter("@endtime",param.End_Time)
             };
            DataSet ds = e.Database.SqlQueryForDynamic("Rpt_RecordCenterIndex", para);
            center.expensecalendar = ds.Tables[0].ToList<ExpenseCalendar>();
            center.arrearsrecorde = ds.Tables[1].ToList<ArrearsRecorde>();
            center.rechargerecorde = ds.Tables[2].ToList<RechargeRecorde>();
            center.RechargeTotal = ds.Tables[3].Rows.Count > 0 ? decimal.Parse(ds.Tables[3].Rows[0][0].ToString()) : 0;
            center.Cash = ds.Tables[4].Rows.Count > 0 ? decimal.Parse(ds.Tables[4].Rows[0][0].ToString()) : 0;
            center.exchangeproduct = ds.Tables[5].ToList<ExchangeRecorde>();
            center.exchangecoupon = ds.Tables[6].ToList<ExchangeRecorde>();
            return center;
        }
    }
}
