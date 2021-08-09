using LocationProject.DAL.IRepositories;
using LocationProject.DataModels;
using LocationProject.DataModels.Contetxts;
using LocationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationProject.DAL.LocationRepository
{
    public class LGVTRepository : ILGVTRepository
    {

        ApplicationContext db = new ApplicationContext();

        public bool Create(LGVTViewModel model)
        {
            try
            {
                LGVT localGovt = new LGVT();
                localGovt.LGVTName = model.LGVTName;
                localGovt.StateId = model.StateId;
                db.LGVTs.Add(localGovt);
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
                LGVT model = db.LGVTs.Find(id);
                if (model != null)
                {
                    db.LGVTs.Remove(model);
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<LGVTViewModel> GetAll()
        {
            List<LGVTViewModel> localGovtsList = new List<LGVTViewModel>();

           // IEnumerable<User> users = db.Users.Include("Projects.Tasks.Messages");
            try
            {
                foreach (var model in db.LGVTs.ToList())
                {
                    LGVTViewModel localGovt = new LGVTViewModel();
                
                    localGovt.LGVTId = model.LGVTId;
                    localGovt.LGVTName = model.LGVTName;
                    localGovt.StateId = model.StateId;

                    localGovt.StateZipCode = model.State.ZipCode;

                    localGovtsList.Add(localGovt);
                }
                return localGovtsList;
            }
            catch
            {
                return null;
            }



        }

        public LGVTViewModel GetById(int id)
        {
            try
            {
                LGVT entity = db.LGVTs.Find(id);
                LGVTViewModel localGovt = new LGVTViewModel();
                localGovt.LGVTId = entity.LGVTId;
                localGovt.LGVTName = entity.LGVTName;
                localGovt.StateId = entity.StateId;
                localGovt.StateZipCode =entity.State.ZipCode;
                return localGovt;
            }
            catch 
            {
                return null;
            }
           
        }

        public bool Update(LGVTViewModel model)
        {

            try
            {
                LGVT entity = db.LGVTs.Find(model.LGVTId);

                if (entity != null)
                {
                    entity.LGVTId = model.LGVTId;
                    entity.LGVTName = model.LGVTName;
                    entity.StateId = model.StateId;
                    db.SaveChanges();

                    return true;
                }

                else return false;
            }
            catch
            {
                return false;
            }



        }



    








    }
}