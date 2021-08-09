using LocationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationProject.DAL.IRepositories
{
  public  interface IStateRepository
    {
        bool Create(StateViewModel model);
        bool Update(StateViewModel model);
        bool Delete(int id);

        IEnumerable<StateViewModel> GetAll();
        StateViewModel GetById(int id);
    }
}
