using LocationProject.CustomSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace LocationProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
           
            {

                HttpCookie encrypTedCookie= Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                if (encrypTedCookie!=null )
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encrypTedCookie.Value);

                    string[] data = ticket.UserData.Split('|');
                    CustomPrincipal principalData = new CustomPrincipal(data[0]);

                    principalData.UserName = data[0];
                    principalData.Name = data[1];
                    principalData.RoleName = data[2];


                    HttpContext.Current.User = principalData;
                }
            
                }



    }
}
