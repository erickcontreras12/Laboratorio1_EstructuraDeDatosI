using System.Web;
using System.Web.Mvc;

namespace Lab1ED1_1C18
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
