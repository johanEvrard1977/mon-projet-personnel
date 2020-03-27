using DAL.Repository;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X_Wing_ASP.net.Controllers
{
    public class AmeliorationController : Controller
    {
        public ActionResult Index()
        {
            AmeliorationRepo AR = new AmeliorationRepo();
            // GET: api/Amelioration
            IEnumerable<Amelioration> p = AR.GetAll();

            return View(p);
        }

        // GET: Amelioration/Details/5
        public ActionResult Details(int id)
        {
            AmeliorationRepo AR = new AmeliorationRepo();
            Amelioration a = new Amelioration();
            a = AR.GetOne(id);
            return View(a);
        }

        // GET: Amelioration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amelioration/Create
        [HttpPost]
        public ActionResult Create(Amelioration collection)
        {
            try
            {
                AmeliorationRepo AR = new AmeliorationRepo();
                if (ModelState.IsValid)
                {
                    AR.Create(new Amelioration() {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Cout = collection.Cout,
                        Description = collection.Description,
                        Pilote = collection.Pilote,
                        TailleMax = collection.TailleMax,
                        TailleMin = collection.TailleMin,
                        Type= collection.Type,
                        Unique = collection.Unique,
                        UnParVaisseau = collection.UnParVaisseau
                        });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Amelioration/Edit/5
        public ActionResult Edit(int id)
        {
            AmeliorationRepo AR = new AmeliorationRepo();
            Amelioration a = new Amelioration();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Amelioration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Amelioration collection)
        {
            try
            {
                AmeliorationRepo AR = new AmeliorationRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Amelioration() {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Cout = collection.Cout,
                        Description = collection.Description,
                        Pilote = collection.Pilote,
                        TailleMax = collection.TailleMax,
                        TailleMin = collection.TailleMin,
                        Type = collection.Type,
                        Unique = collection.Unique,
                        UnParVaisseau = collection.UnParVaisseau
                    });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Amelioration/Delete/5
        public ActionResult Delete(int id)
        {
            AmeliorationRepo AR = new AmeliorationRepo();
            Amelioration a = new Amelioration();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Amelioration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Amelioration collection)
        {
            try
            {
                AmeliorationRepo AR = new AmeliorationRepo();
                if (ModelState.IsValid)
                {
                    AR.Delete(id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
