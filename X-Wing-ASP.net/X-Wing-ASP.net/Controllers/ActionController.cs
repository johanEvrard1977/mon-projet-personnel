using DAL.Repository;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace X_Wing_ASP.net.Controllers
{
    public class ActionController : Controller
    {
        // GET: Action
        public ActionResult Index()
        {
            ActionRepo AR = new ActionRepo();
            // GET: api/Action
            IEnumerable<Actions> p = AR.GetAll();
            
            return View(p);
        }

        // GET: Action/Details/5
        public ActionResult Details(int id)
        {
            ActionRepo AR = new ActionRepo();
            Actions a = new Actions();
           a = AR.GetOne(id);
            return View(a);
        }

        // GET: Action/Create
        public ActionResult Create()
        {
            VaisseauRepo VR = new VaisseauRepo();

            ViewBag.vaisseaux = new SelectList(VR.GetAll(), "Id", "Nom", "selectedValue");
            return View();
        }

        // POST: Action/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ActionRepo AR = new ActionRepo();
                if (ModelState.IsValid)
                {
                    AR.Create(new Actions() { Nom = collection["Nom"], XIDVaisseau = int.Parse(collection["vaisseaux"]) });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Action/Edit/5
        public ActionResult Edit(int id)
        {
            VaisseauRepo VR = new VaisseauRepo();

            ViewBag.vaisseaux = new SelectList(VR.GetAll(), "Id", "Nom", "selectedValue");
            ActionRepo AR = new ActionRepo();
            Actions a = new Actions();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Action/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ActionRepo AR = new ActionRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Actions() { Nom = collection["Nom"], XIDVaisseau = int.Parse(collection["vaisseaux"]) });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Action/Delete/5
        public ActionResult Delete(int id)
        {
            ActionRepo AR = new ActionRepo();
            Actions a = new Actions();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Action/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Actions collection)
        {
            try
            {
                ActionRepo AR = new ActionRepo();
                AR.Delete(id, new Actions() { Id = collection.Id, Nom = collection.Nom });
                
                return RedirectToAction("Index");
            }
            catch
            {
                ActionRepo AR = new ActionRepo();
                Actions a = new Actions();
                a = AR.GetOne(id);
                return View(a);
            }
        }
    }
}
