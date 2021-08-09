using LocationProject.CustomSecurity;
using LocationProject.DAL.IRepositories;
using LocationProject.DAL.LocationRepository;
using LocationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationProject.Controllers.Location
{
    [CustomAuthentication]

    public class StateController : Controller
    {
        IStateRepository repo = new StateRepository();

        public ActionResult GetAll()
        {
          IEnumerable<StateViewModel> model= repo.GetAll();
           return View(model);
        }

        public ActionResult Details(int id)
        {
            StateViewModel model = repo.GetById(id);
            return View(model);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (repo.Create(model))
                {
                    return RedirectToAction("GetAll");
                }
                else
                {
                  ModelState.AddModelError("", "Operation not successful");
                    return View();
                }

            }
            return Content("Operation not successful");
        }




      
        public ActionResult Edit(int id )
        {
           var model=repo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StateViewModel model)
        {
            if (repo.Update(model))
            {
                return RedirectToAction("GetAll");
            }

            else
            {
                return View();
            }
           
           
        }



      
        public ActionResult Delete(int id)
        {
           
            if (repo.Delete(id))
            {
                return RedirectToAction("GetAll");
            }

            else
            {
                return RedirectToAction("GetAll");
            }


        }








    }
}