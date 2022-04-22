using System.Web;
using System.Web.Mvc;

namespace _1MVCMetV2_Cntrllr
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
