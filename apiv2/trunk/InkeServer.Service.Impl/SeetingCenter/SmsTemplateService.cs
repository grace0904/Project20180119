using AutoMapper;
using Inke.Common.Exceptions;
using Inke.Common.Extentions;
using Inke.Common.Helpers;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using InkeServer.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    public class SmsTemplateService : ServiceBase, ISmsTemplateService
    {
        //标记为注入对象
        [InjectionConstructor]
        public SmsTemplateService() { }

        public List<SmsTemplateIDAndName> GetSmsTemplateIDAndName(MerchantIdRequest param)
        {
            if (param.Merchant_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.MerhcantCodeWrong.Name());

            List<SmsTemplateIDAndName> SmsTemplateData = new List<SmsTemplateIDAndName>();

            SmsTemplateData = (from s in Entities.Bas_SmsTemplateCustom
                               join c in Entities.Sys_SmsTemplate on s.SmsTemplate_ID equals c.SmsTemplate_ID
                               where s.Merchant_ID == param.Merchant_ID
                               select c).MapTo<SmsTemplateIDAndName>();
            return SmsTemplateData;
        }

        public List<SmsTemplateList> GetSmsTemplateList(MerchantIdRequest param)
        {
            if (param.Merchant_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.MerhcantCodeWrong.Name());

            List<SmsTemplateList> SmsTemplateData = new List<SmsTemplateList>();

            SmsTemplateData = (from s in Entities.Bas_SmsTemplateCustom
                               join c in Entities.Sys_SmsTemplate on s.SmsTemplate_ID equals c.SmsTemplate_ID
                               where s.Merchant_ID == param.Merchant_ID
                               select new SmsTemplateList
                               {
                                   SmsTemplate_ID = c.SmsTemplate_ID,
                                   SmsTemplate_Name = c.SmsTemplate_Name,
                                   Custom_ID = s.Custom_ID,
                                   Custom_Send = s.Custom_Send,
                                   Custom_SendDate = s.Custom_SendDate
                               }).ToList();
            return SmsTemplateData;
        }

        public SmsTemplateCustom SmsTemplateCustom(SmsTemplateRequest param)
        {
            SmsTemplateCustom SmsTemplateCustom = new SmsTemplateCustom();
            if (param.Merchant_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.MerhcantCodeWrong.Name());

            SmsTemplateCustom = (from f in Entities.Bas_SmsTemplateCustom
                                 where f.Merchant_ID == param.Merchant_ID && f.SmsTemplate_ID == param.SmsType.ToString()
                                 select f).FirstOrDefault().MapTo<SmsTemplateCustom>();
            return SmsTemplateCustom;
        }

        public void Update(SmsTemplateUpdate model)
        {
            #region Update
            var temp = (from m in Entities.Bas_SmsTemplateCustom
                        where m.Custom_ID == model.Custom_ID
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());
            //判断该数据是否未修改
            var query = (from m in Entities.Bas_SmsTemplateCustom
                         where m.Custom_ID == model.Custom_ID && m.Custom_Send == model.Custom_Send
                         select m);
            query = query.WhereIf(
                   l => l.Custom_SendDate == model.Custom_SendDate.Value, model.Custom_SendDate.HasValue);
            if (query.FirstOrDefault() != null)
                return;

            temp.Custom_Send = model.Custom_Send;
            if (model.Custom_SendDate.HasValue)
                temp.Custom_SendDate = model.Custom_SendDate;

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

    }
}
