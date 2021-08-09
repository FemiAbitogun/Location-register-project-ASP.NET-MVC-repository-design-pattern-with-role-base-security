using LocationProject.DAL.IRepositories;
using LocationProject.DataModels;
using LocationProject.DataModels.Contetxts;
using LocationProject.Models.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace LocationProject.DAL
{
    public class UserRepository :IUserRepository
    {
        ApplicationContext db = new ApplicationContext();
        public bool Create(UserViewModel model,string imagePath, string imageFileName)
        {
            try
            {
                User userModel = new User();
               
                userModel.UserImagePath = imagePath;
                userModel.UserImageFileName = imageFileName;
                userModel.Name = model.Name;
                userModel.UserName = model.UserName;
                userModel.Password = model.Password;
                userModel.RoleName = model.RoleName;
               
                db.Users.Add(userModel);
                db.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {

               User model= db.Users.Find(id);
                db.Users.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public UserViewModel GetById(int id)
        {
            try
            {
                User model = db.Users.Find(id);

                UserViewModel user = new UserViewModel();
                user.UserId = model.UserId;
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.RoleName = model.RoleName;
                user.Name = model.Name;
                user.UserImagePath = model.UserImagePath;
                user.UserImageFileName = model.UserImageFileName;
                return user;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            try
            {
                foreach (User model in db.Users.ToList())
                {
                    UserViewModel user = new UserViewModel();
                    user.UserId = model.UserId;
                    user.UserName = model.UserName;
                    user.Password = model.Password;
                    user.RoleName = model.RoleName;
                    user.Name = model.Name;
                    user.UserImagePath = model.UserImagePath;
                    users.Add(user);
                }
                return (users);
            }
            catch (Exception)
            {
                return null;
            }
        }



        public bool Update(UserViewModel model)
        {
            try
            {
                User userModel = db.Users.Find(model.UserId);
                userModel.Name = model.Name;
                userModel.UserName = model.UserName;
                userModel.Password = model.Password;
                userModel.RoleName = model.RoleName;
                db.Users.Add(userModel);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public UserViewModel ValidateUser(LoginViewModel model)
        {


            try
            {
                User AuthenticatedUser = db.Users.Where(q => q.UserName == model.UserName && q.Password == model.Password).FirstOrDefault();
                if (AuthenticatedUser != null)
                {
                    UserViewModel userViewModel = new UserViewModel();
                    userViewModel.UserName = AuthenticatedUser.UserName;
                    userViewModel.Password = AuthenticatedUser.Password;
                    userViewModel.Name = AuthenticatedUser.Name;
                    userViewModel.RoleName = AuthenticatedUser.RoleName;

                    return userViewModel;
                }
                else return null;
            }
            catch 
            {
                return null;
            }




        }
    }
}