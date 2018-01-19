
namespace Inke.Common.Helpers
{
    public class CheckInput
    {
        /// <summary>
        /// 检查字符串是否为手机号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckMobile(string str)
        { 
            //检查规则 1 开头 并且是11位
            bool Condition1 = false;
            bool Condition2 = false;
            if (str.Substring(0, 1) == "1")
                Condition1 = true;
            if (str.Length == 11)
                Condition2 = true;

            if (Condition1 == true && Condition2 == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
