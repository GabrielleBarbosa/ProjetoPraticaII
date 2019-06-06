using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using YourLife.Filtro;

namespace YourLife.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //registrar um filtro global 
            filters.Add(new AutorizacaoFilterAttribute());
        }
    }
}