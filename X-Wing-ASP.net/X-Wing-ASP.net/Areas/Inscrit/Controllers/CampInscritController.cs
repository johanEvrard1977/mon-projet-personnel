using DAL.Repository;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X_Wing_ASP.net.Areas.Inscrit.Controllers
{
    public class CampInscritController : Controller
    {
        public ActionResult Index()
        {
            CampRepo AR = new CampRepo();
            // GET: api/Camp
            IEnumerable<Camp> p = AR.GetAll();

            return View(p);
        }

        // GET: Camp/Details/5
        public ActionResult Details(int id)
        {
            CampRepo AR = new CampRepo();
            Camp a = new Camp();
            a = AR.GetOne(id);
            return View(a);
        }

        // GET: Camp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CampRepo AR = new CampRepo();
                if (ModelState.IsValid)
                {
                    AR.Create(new Camp() { Nom = collection["Nom"] });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Camp/Edit/5
        public ActionResult Edit(int id)
        {
            CampRepo AR = new CampRepo();
            Camp a = new Camp();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Camp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Camp collection)
        {
            try
            {
                CampRepo AR = new CampRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Camp { Id = collection.Id, Nom = collection.Nom });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Camp/Delete/5
        public ActionResult Delete(int id)
        {
            CampRepo AR = new CampRepo();
            Camp a = new Camp();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Camp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Camp collection)
        {
            try
            {
                CampRepo AR = new CampRepo();
                AR.Delete(id, new Camp { Id = collection.Id, Nom = collection.Nom });
                
                return RedirectToAction("Index");
            }
            catch
            {
                CampRepo AR = new CampRepo();
                Camp a = new Camp();
                a = AR.GetOne(id);
                return View(a);
            }
        }
    }
}