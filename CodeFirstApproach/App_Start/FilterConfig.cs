using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Filters;

namespace CodeFirstApproach.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGLobalFilter(GlobalFilterCollection filters)
        {
            filters.Add(new MyAuthenticationAttribute());
        }
    }
}