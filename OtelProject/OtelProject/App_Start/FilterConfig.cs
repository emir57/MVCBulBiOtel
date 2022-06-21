using System.Web;
using System.Web.Mvc;

namespace OtelProject
{
    public class FilterConfig
    {
#pragma warning disable CS0246 // The type or namespace name 'GlobalFilterCollection' could not be found (are you missing a using directive or an assembly reference?)
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
#pragma warning restore CS0246 // The type or namespace name 'GlobalFilterCollection' could not be found (are you missing a using directive or an assembly reference?)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
