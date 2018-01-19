using System;

namespace Inke.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public string Code { get; set; }

        public BusinessException(string code)
        {
            this.Code = code;
        }

        public BusinessException(string code, string msg)
            : base(msg)
        {
            this.Code = code;
        }
    }
}
