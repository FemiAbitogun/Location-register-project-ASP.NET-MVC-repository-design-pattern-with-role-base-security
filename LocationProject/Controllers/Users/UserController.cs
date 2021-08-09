using LocationProject.CustomSecurity;
using LocationProject.DAL;
using LocationProject.DAL.IRepositories;
using LocationProject.Models.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LocationProject.Controllers.Users
{

    //[CustomAuthentication]
    //[CustomAuthorization(Role = "admin")]

    public class UserController : Controller
    {
        IUserRepository repo = new UserRepository();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                string IncomingFileName = Path.GetFileNameWithoutExtension(model.UserImageFile.FileName);
                string extension = Path.GetExtension(model.UserImageFile.FileName);
                string fileName = IncomingFileName + new Random().Next(1000).ToString() + extension;
                string storage = Server.MapPath("~/Images/"+ fileName) ;
                string userImagePath = "~/Images/" + fileName;
                model.UserImageFile.SaveAs(storage);
             
                if (repo.Create(model, userImagePath, fileName))
                {
                    return RedirectToRoute(new { Controller = "User", Action = "GetAll" });
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create new user");
                    return View();
                }
            }
          
            else
            {
                ModelState.AddModelError("", "Invalid datas....");
                return View();
            }        
        }


        public ActionResult GetAll()
        {
           
            IEnumerable<UserViewModel> users = repo.GetUsers();         
             return View(users);
        }


        public ActionResult  Details(int id)
        {
            UserViewModel  model=repo.GetById(id);
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            UserViewModel model = repo.GetById(id);
            return View (model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (repo.Update(model))
                {
                    return RedirectToRoute(new { Controller = "User", Action = "GetAll" });
                }
                else
                {
                    ModelState.AddModelError("", "failed to update");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "invalid data..");
                return View();
            }
        }




        public ActionResult Delete(int id)
        {
            var user = repo.GetById(id);
            if (repo.Delete(id))
            {
                string path= Server.MapPath("~/Images/" + user.UserImageFileName);
              //  System.IO.File.SetAttributes(path, FileAttributes.Normal);
                System.IO.File.Delete(path);
                return RedirectToRoute(new { Controller = "User", Action = "GetAll" });

            }

            else
            {
                ModelState.AddModelError("", "failed to delete user....");
                return RedirectToRoute(new { Controller = "User", Action = "GetAll" });
            }
      
        }

   
    
    
    
    
    }  
}