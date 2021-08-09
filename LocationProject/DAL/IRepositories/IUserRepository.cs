using LocationProject.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace LocationProject.DAL.IRepositories
{
   public interface IUserRepository
    {
        bool Create(UserViewModel model, string imagePath, string imageFileName);
        bool Update(UserViewModel model);
        bool Delete(int id);
        UserViewModel GetById(int id);
        IEnumerable<UserViewModel> GetUsers();
        UserViewModel ValidateUser(LoginViewModel model);
    }
}
