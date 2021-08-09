using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace LocationProject.CustomSecurity
{

    //for customAuthentication.......
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public CustomPrincipal(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        //for authorization...........
        public bool IsInRole(string role)
        {
            if (role == RoleName)
            {
                return true;
            }
            else 
                return false;

        }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }

    }


}