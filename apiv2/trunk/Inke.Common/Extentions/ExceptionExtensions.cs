using Inke.Common.Exceptions;

namespace Inke.Common.Extentions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// 不允许为空验证，为空则抛出BusinessException异常，传入错误码生成对应的错误返回信息。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="code"></param>
        public static void MustNotNull<T>(this T obj, string code) where T : class
        {
            if (obj == null)
                throw new BusinessException(code);
        }

        /// <summary>
        /// 必须为空验证，不为空则抛出BusinessException异常，传入错误码生成对应的错误返回信息。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="code"></param>
        public static void MustIsNull<T>(this T obj, string code) where T : class
        {
            if (obj != null)
                throw new BusinessException(code);
        }
    }
}
