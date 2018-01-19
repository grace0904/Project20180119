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
using System.Linq;

namespace InkeServer.Service.Impl
{
    public class LoginService : ServiceBase, ILoginService
    {
        //标记为注入对象
        [InjectionConstructor]
        public LoginService() { }

        public LoginResult Login(LoginRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            #region 登录验证

            //根据商家NUMBER查询到商家ID
            var merchant = (from n in Entities.Bas_Merchant
                            where n.Merchant_Number == param.Merchant_Number
                            select n).FirstOrDefault();
             
            merchant.MustNotNull(ResultCode.MerhcantCodeWrong.Name());
            var merchantId = merchant.Merchant_ID;
            if (merchantId.IsNullOrEmpty())
                throw new BusinessException(ResultCode.MerhcantCodeWrong.Name());

            //对account_Password进行MD5加密并转换小写 
            string Password = MD5er.Encrypt(param.Account_Password.ToString().ToLower());
            var AccountInfo = (from n in Entities.Bas_Account
                               where n.Merchant_ID == merchantId && n.Account_Login == param.Account_Login && n.Account_Password == Password && n.Del != 1 && n.Account_Status == 1
                               select n).FirstOrDefault();
            //若登录失败是由于密码不多还是账户不存在造成的
            if (AccountInfo==null)
            { 
                var Accountcheck=(from n in Entities.Bas_Account
                               where n.Merchant_ID == merchantId && n.Account_Login == param.Account_Login && n.Del != 1 && n.Account_Status == 1 select n).FirstOrDefault();
                if (Accountcheck==null)
                    throw new BusinessException(ResultCode.AccountInexistence.Name());
                throw new BusinessException(ResultCode.PasswordWrong.Name());
            }

            #endregion
            #region 判断是否允许登录该终端

            //判断是否允许登录该终端
            if (param.TerminalType == (int)TerminalType.CRM && (AccountInfo.Account_LoginCRM ?? 0) == 0)
                throw new BusinessException(ResultCode.NotLoginCRM.Name());

            if (param.TerminalType == (int)TerminalType.POS && (AccountInfo.Account_LoginCRM ?? 0) == 0)
                throw new BusinessException(ResultCode.NotLoginPOS.Name());

            if (param.TerminalType == (int)TerminalType.KFT && (AccountInfo.Account_LoginCRM ?? 0) == 0)
                throw new BusinessException(ResultCode.NotLoginKFT.Name());

             if (param.TerminalType == (int)TerminalType.INPOS && (AccountInfo.Account_LoginINPOS ?? 0) == 0)
                throw new BusinessException(ResultCode.NotLoginINPOS.Name());
            
            #endregion
            #region 完善登录初始化信息
            var result = AccountInfo.MapTo<LoginResult>();
            //获取当前用户所在店铺名称
            result.Shop_Name = (from l in Entities.Bas_Shop
                                where l.Shop_ID == AccountInfo.Shop_ID
                                select l.Shop_Name).FirstOrDefault();
            result.Merchant_Name = merchant.Merchant_Name;
            result.Merchant_ShortName = merchant.Merchant_ShortName;
            #endregion

            return result;
        }
    }
}
