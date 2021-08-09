using LocationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationProject.DAL.IRepositories
{
  public  interface ILGVTRepository
    {
        bool Create(LGVTViewModel model);
        bool Update(LGVTViewModel model);
        bool Delete(int id);

        IEnumerable<LGVTViewModel> GetAll();
        LGVTViewModel GetById(int id);
    }
}
