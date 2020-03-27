using DAL.Repository;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X_Wing_ASP.net.Controllers
{
    public class PiloteController : Controller
    {
        // GET: Pilote
        public ActionResult Index()
        {
            PiloteRepo AR = new PiloteRepo();
            // GET: api/Pilote
            IEnumerable<Pilote> p = AR.GetAll();

            return View(p);
        }

        // GET: Pilote/Details/5
        public ActionResult Details(int id)
        {
            PiloteRepo AR = new PiloteRepo();
            Pilote a = new Pilote();
            a = AR.GetOne(id);
            return View(a);
        }

        // GET: Pilote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pilote/Create
        [HttpPost]
        public ActionResult Create(Pilote collection)
        {
            try
            {
                PiloteRepo AR = new PiloteRepo();
                if (ModelState.IsValid)
                {
                    AR.Create(new Pilote() {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Amelioration = collection.Amelioration,
                        Camp = collection.Camp,
                        Commentaires = collection.Commentaires,
                        Cout = collection.Cout,
                        Type = collection.Type,
                        Unique = collection.Unique,
                        Vaisseaux = collection.Vaisseaux,
                        ValeurPilotage = collection.ValeurPilotage
                        });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pilote/Edit/5
        public ActionResult Edit(int id)
        {
            PiloteRepo AR = new PiloteRepo();
            Pilote a = new Pilote();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Pilote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pilote collection)
        {
            try
            {
                PiloteRepo AR = new PiloteRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Pilote() {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Amelioration = collection.Amelioration,
                        Camp = collection.Camp,
                        Commentaires = collection.Commentaires,
                        Cout = collection.Cout,
                        Type = collection.Type,
                        Unique = collection.Unique,
                        Vaisseaux = collection.Vaisseaux,
                        ValeurPilotage = collection.ValeurPilotage
                    });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pilote/Delete/5
        public ActionResult Delete(int id)
        {
            PiloteRepo AR = new PiloteRepo();
            Pilote a = new Pilote();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Action/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pilote collection)
        {
            try
            {
                PiloteRepo AR = new PiloteRepo();
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