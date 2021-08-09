using LocationProject.DAL;
using LocationProject.DAL.IRepositories;
using LocationProject.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LocationProject.Controllers.Account
{
    public class LoginController : Controller
    {
        IUserRepository repo = new UserRepository();
      
        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("LoginPage");
        }

        [HttpPost]
        public ActionResult LoginPage(LoginViewModel model)
        {
           UserViewModel User = repo.ValidateUser(model);
            if (User != null)
            {
                string UserData = string.Format("{0}|{1}|{2}", User.UserName,User.Name,User.RoleName);
                //creating ticket/.......
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, User.UserName,DateTime.Now,DateTime.Now.AddSeconds(10),false,UserData);
                // ticket encryption......
                string encrytedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrytedTicket);
                //add to cookie container response.......
                Response.Cookies.Add(cookie);
                return RedirectToRoute(new { Controller = "User", action = "GetAll" });
            }
            else
            return View();
        }








    }




}