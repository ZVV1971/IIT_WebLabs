using System.Web;
using System.Web.Mvc;

namespace ZVV_Web_Lab_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
