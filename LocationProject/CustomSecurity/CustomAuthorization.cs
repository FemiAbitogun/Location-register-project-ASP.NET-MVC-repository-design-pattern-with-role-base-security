using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LocationProject.CustomSecurity
{
    public class CustomAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public string Role { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
               if( !filterContext.HttpContext.User.IsInRole(Role))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "State", Action = "GetAll" }));
                }           
            }
        }
    }
}