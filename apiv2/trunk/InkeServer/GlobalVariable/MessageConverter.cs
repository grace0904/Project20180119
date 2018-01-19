using Inke.Common.Exceptions;
using InkeServer.Enums;
using InkeServer.Model;
using InkeServer.Resources;
using System;

namespace InkeServer.GlobalVariable
{
    public static class MessageConverter
    {
        #region ErrorResult

        public static BaseResult<object> ErrorResult(this BusinessException ex)
        {
            var code = ex.Code.ToEnum<ResultCode>();
            return MessageConverter.ErrorResult(code.Name(), ex.Message);
        }

        public static BaseResult<object> ErrorResult(this ResultCode code)
        {
            return MessageConverter.ErrorResult(code.Name());
        }

        private static BaseResult<object> ErrorResult(string name, string cause = "")
        {
            var msg = MessageCode.ResourceManager.GetString(name);
            var code = name.ToEnum<ResultCode>();
            return new BaseResult<object>()
            {
                Code = code.Value().ToString(),
                Message = msg,
                Cause = cause,
                Data = null
            };
        }

        #endregion

        #region CompleteResult

        public static BaseResult<T> CompleteResult<T>(this T data) where T : class
        {
            return GetCompleteResult(data);
        }

        public static BaseResult<object> CompleteResult()
        {
            var code = ResultCode.Complete.Value().ToString();
            var msg = MessageCode.ResourceManager.GetString(ResultCode.Complete.Name());

            return new BaseResult<object>()
            {
                Code = code,
                Message = msg,
                Data = null
            };
        }

        public static BaseResult<T> GetCompleteResult<T>(T data = null) where T : class
        {
            var code = ResultCode.Complete.Value().ToString();
            var msg = MessageCode.ResourceManager.GetString(ResultCode.Complete.Name());

            return new BaseResult<T>()
            {
                Code = code,
                Message = msg,
                Data = data
            };
        }

        #endregion
    }
}
