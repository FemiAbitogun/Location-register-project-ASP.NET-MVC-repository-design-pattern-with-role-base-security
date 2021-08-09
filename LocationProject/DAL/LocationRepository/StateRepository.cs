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
    public class StateRepository : IStateRepository
    {
        ApplicationContext db = new ApplicationContext();


        public StateViewModel GetById(int id)
        {
            try
            {
                State state = db.States.Find(id);
                StateViewModel model = new StateViewModel();
                model.StateId = state.StateId;
                model.Name = state.Name;
                model.ZipCode = state.ZipCode;
                return model;
            }
            catch 
            {

                return null;
            }


        }




        public IEnumerable<StateViewModel> GetAll()
        {
           
            List<StateViewModel> listOfStates = new List<StateViewModel>();



            try
            {
                foreach (State state in db.States)
                {
                    StateViewModel model = new StateViewModel();
                    model.StateId = state.StateId;
                    model.Name = state.Name;
                    model.ZipCode = state.ZipCode;
                    listOfStates.Add(model);
                }

                return listOfStates;
            }
            catch 
            {

                return null;
            }
           
        }

        public bool Create(StateViewModel model)
        {
            try
            {
                State StateObject = new State();
                StateObject.Name = model.Name;
                StateObject.ZipCode = model.ZipCode;
                db.States.Add(StateObject);
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
                State model = db.States.Find(id);
                db.States.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
        }

      

    

        public bool Update(StateViewModel model)
        {

            try
            {
                State state = db.States.Find(model.StateId);
                if (state != null)
                {
                    state.Name = model.Name;
                    state.ZipCode = model.ZipCode;
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