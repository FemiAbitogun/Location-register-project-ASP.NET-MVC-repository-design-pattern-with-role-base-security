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
    public class LocalGvtController : Controller
    {
        // GET: LocalGvt

        ILGVTRepository repo = new LGVTRepository();
        IStateRepository repoState = new StateRepository();

        public ActionResult GetAll()
        {
            IEnumerable<LGVTViewModel> model = repo.GetAll();
            return View(model);
        }


        

        public ActionResult Create()
        {  
            ViewBag.stateID = repoState.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(LGVTViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (repo.Create(model))
                {
                    return RedirectToAction("GetAll");
                }

                else
                {
                    ModelState.AddModelError("", "failed to save to database.....");
                    return View();
                }
            }

            ModelState.AddModelError("", "Invalid entry.....");
            return View();
        }

      

        public ActionResult Details(int id)
        {
            LGVTViewModel model = repo.GetById(id);
            return View(model);
        }



        public ActionResult Edit(int id)
        {
            ViewBag.stateID = repoState.GetAll();
            LGVTViewModel model = repo.GetById(id);
            return View(model);
        }


    }
}