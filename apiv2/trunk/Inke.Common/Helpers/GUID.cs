
namespace Inke.Common.Helpers
{
    public class GUID
    {
         public static string CreateGUID()
         {
             string guid = System.Guid.NewGuid().ToString();
             guid = guid.Replace("-", "");
             guid = guid.ToUpper();
             return guid;
         }
    }
}
