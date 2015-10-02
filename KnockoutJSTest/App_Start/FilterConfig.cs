using KnockoutJSTest.Filters;
using System.Web;
using System.Web.Mvc;

namespace KnockoutJSTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new OnExceptionAttribute());
            filters.Add(new BasicAuthenticationAttribute());
        }
    }
}
