using System.Web;
using System.Web.Mvc;

namespace Dar_e_Arqam_pwd_isb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}