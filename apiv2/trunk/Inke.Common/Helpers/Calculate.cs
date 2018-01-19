
namespace Inke.Common.Helpers
{
    public class Calculate
    {
        public static decimal Calc(decimal a, decimal b, decimal c)
        {
            if (c == 0) return 0;
            return a * b / c;
        }
    }
}
