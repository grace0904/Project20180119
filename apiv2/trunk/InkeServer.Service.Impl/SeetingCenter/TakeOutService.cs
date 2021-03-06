﻿using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inke.Common.Extentions;
using AutoMapper;
using EntityFramework.Extensions;
using System.Transactions;
using System.Data.Entity;
using Inke.Common.Helpers;
using Inke.Common.Exceptions;

namespace InkeServer.Service.Impl
{
    public class TakeOutService : ServiceBase, ITakeOutService
    {
        /// <summary>
        /// 获取相关外卖信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public TakeOutResult GetTakeOutInfo(ShopIdRequest param)
        {
            TakeOutResult result = new TakeOutResult();
            var shopinfo = (from a in Entities.Bas_Shop
                            where a.Del != 1 && a.Shop_ID == param.Shop_ID
                            select a).FirstOrDefault();

            result = shopinfo.MapTo<TakeOutResult>();
            result.EmployeePositionInfo =  (from a in Entities.Bas_ShopEmployee
                                                    join b in Entities.Bas_Account on a.Employee_ID equals b.Employee_ID
                                                    join c in Entities.Bas_MerchantPosition on b.Position_ID equals c.Position_ID
                                                    where c.Del != 1 && b.Del != 1 && a.Del != 1 &&
                                                    a.Shop_ID == param.Shop_ID
                                                    select new EmployeePositionInfo
                                                    {
                                                        Employee_ID = a.Employee_ID,
                                                        Position_ID = b.Position_ID,
                                                        Employee_Name = a.Employee_Name,
                                                        Employee_Tel = a.Employee_Tel,
                                                        Position_Name = c.Position_Name
                                                    }).OrderBy(c => c.Position_Name).ToList().MapTo<EmployeePositionInfo>();
            return result;
        } 
        public void Update(TakeOutUpdate param)
        {
            #region Update
            var temp = (from m in Entities.Bas_Shop
                        where m.Shop_ID == param.Shop_ID && m.Del != 1
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            temp.Deliveryamount = param.Deliveryamount;
            temp.Takeoutcost = param.Takeoutcost;
            temp.TakeOutTimeBegin = param.TakeOutTimeBegin;
            temp.OperationTime = DateTime.Now;
            temp.TakeOutTimeEnd = param.TakeOutTimeEnd;
            temp.TakeOutSmsEmployeeID = param.TakeOutSmsEmployeeID;
            temp.TakeOutSmsTel = param.TakeOutSmsTel;
            temp.TakeOutStatus = param.TakeOutStatus;
            temp.PayOnDelivery = param.PayOnDelivery; 
            temp.Operator = param.Operator;
            temp.Del = 0;

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }
    }
}
