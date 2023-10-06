using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Filters
{
    public class AdminAuthorizationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.IsInRole("Admin"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}