using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface ISmsTemplateService
    {
        List<SmsTemplateIDAndName> GetSmsTemplateIDAndName(MerchantIdRequest param);
        SmsTemplateCustom SmsTemplateCustom(SmsTemplateRequest param);
        List<SmsTemplateList> GetSmsTemplateList(MerchantIdRequest param);
        void Update(SmsTemplateUpdate model);
    }
}
