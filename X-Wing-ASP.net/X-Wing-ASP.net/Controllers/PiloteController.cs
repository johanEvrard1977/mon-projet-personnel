using DAL.Repository;
using DAL.ViewModels;
using DalXwing.Models;
using System;
using System.Collections.Generic;
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
            IEnumerable<View> p = AR.GetAll();

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
            
            CampRepo CR = new CampRepo();
            ViewBag.camp = new SelectList(CR.GetAll(), "Id", "Nom", "selectedValue");

            VaisseauRepo VR = new VaisseauRepo();
            
            ViewBag.vaisseaux = new SelectList(VR.GetAll(), "Id", "Nom", "selectedValue");

            TypeAmeliorationRepo TAR = new TypeAmeliorationRepo();

            ViewBag.type = new SelectList(TAR.GetAll(), "Id", "Nom", "selectedValue");
            return View();
        }

        // POST: Pilote/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PiloteRepo AR = new PiloteRepo();
                //if (ModelState.IsValid)
                //{
                    AR.Create(new Pilote() {
                        Nom = collection["Nom"],
                        ValeurPilotage = int.Parse(collection["ValeurPilotage"]),
                        Commentaires = collection["Commentaires"],
                        Cout = int.Parse(collection["Cout"]),
                        Unique = bool.Parse(collection["Unique"]),
                        XIDCamp = int.Parse(collection["camps"]),
                        XIDVaisseau = int.Parse(collection["vaisseaux"]),
                        XIDType = int.Parse(collection["type"])
                    });
                return RedirectToAction("Index");
            }
            catch
            {
                CampRepo CR = new CampRepo();
                ViewBag.camp = new SelectList(CR.GetAll(), "Id", "Nom", "selectedValue");

                VaisseauRepo VR = new VaisseauRepo();

                ViewBag.vaisseaux = new SelectList(VR.GetAll(), "Id", "Nom", "selectedValue");

                TypeAmeliorationRepo TAR = new TypeAmeliorationRepo();

                ViewBag.type = new SelectList(TAR.GetAll(), "Id", "Nom", "selectedValue");
                return View();
            }
        }

        // GET: Pilote/Edit/5
        public ActionResult Edit(int id)
        {
            CampRepo CR = new CampRepo();
            ViewBag.camp = new SelectList(CR.GetAll(), "Id", "Nom", "selectedValue");

            VaisseauRepo VR = new VaisseauRepo();
            ViewBag.vaisseaux = new SelectList(VR.GetAll(), "Id", "Nom", "selectedValue");

            TypeAmeliorationRepo TAR = new TypeAmeliorationRepo();
            ViewBag.type = new SelectList(TAR.GetAll(), "Id", "Nom", "selectedValue");

            PiloteRepo AR = new PiloteRepo();
            Pilote a = new Pilote();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Pilote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                PiloteRepo AR = new PiloteRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Pilote() {
                        Nom = collection["Nom"],
                        ValeurPilotage = int.Parse(collection["ValeurPilotage"]),
                        Commentaires = collection["Commentaires"],
                        Cout = int.Parse(collection["Cout"]),
                        Unique = bool.Parse(collection["Unique"]),
                        XIDCamp = int.Parse(collection["camps"]),
                        XIDVaisseau = int.Parse(collection["vaisseaux"]),
                        XIDType = int.Parse(collection["type"]),
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
                AR.Delete(id, new Pilote()
                    {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        ValeurPilotage = collection.ValeurPilotage,
                        Commentaires = collection.Commentaires,
                        Cout = collection.Cout,
                        Unique = collection.Unique,
                        XIDCamp = collection.XIDCamp,
                        XIDVaisseau = collection.XIDVaisseau
                    });
                return RedirectToAction("Index");
            }
            catch
            {
                PiloteRepo AR = new PiloteRepo();
                Pilote a = new Pilote();
                a = AR.GetOne(id);
                return View(a);
            }
        }
    }
}