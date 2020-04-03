using DAL.Repository;
using DAL.ViewModels;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X_Wing_ASP.net.Controllers
{
    public class VaisseauxController : Controller
    {
        // GET: Vaisseaux
        public ActionResult Index()
        {
            VaisseauRepo AR = new VaisseauRepo();
            // GET: api/Action
            IEnumerable<View> p = AR.GetAll();

            return View(p);
        }

        // GET: Vaisseau/Details/5
        public ActionResult Details(int id)
        {
            VaisseauRepo AR = new VaisseauRepo();
            Vaisseaux a = new Vaisseaux();
            a = AR.GetOne(id);
            return View(a);
        }

        // GET: Vaisseau/Create
        public ActionResult Create()
        {
            ActionRepo AR = new ActionRepo();

            ViewBag.action = new SelectList(AR.GetAll(), "Id", "Nom", "selectedValue");
            return View();
        }

        // POST: Vaisseau/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                VaisseauRepo AR = new VaisseauRepo();
                if (ModelState.IsValid)
                {
                    AR.Create(new Vaisseaux()
                    {
                        XIDAction = int.Parse(collection["action"]),
                        Nom = collection["Nom"],
                        Bouclier = int.Parse(collection["Bouclier"]),
                        Capacite = collection["Capacite"],
                        Energie = int.Parse(collection["Energie"]),
                        Structure = int.Parse(collection["Structure"]),
                        Taille = collection["Taille"],
                        ValeurAgilite = int.Parse(collection["ValeurAgilite"]),
                        ValeurArmePrincipale = int.Parse(collection["ValeurArmePrincipale"])
                    });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vaisseau/Edit/5
        public ActionResult Edit(int id)
        {
            ActionRepo AR = new ActionRepo();

            ViewBag.action = new SelectList(AR.GetAll(), "Id", "Nom", "selectedValue");
            VaisseauRepo VR = new VaisseauRepo();
            Vaisseaux a = new Vaisseaux();
            a = VR.GetOne(id);
            return View(a);
        }

        // POST: Vaisseau/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                VaisseauRepo AR = new VaisseauRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Vaisseaux()
                    {
                        Nom = collection["Nom"],
                        Bouclier = int.Parse(collection["Bouclier"]),
                        Capacite = collection["Capacite"],
                        Energie = int.Parse(collection["Energie"]),
                        Structure = int.Parse(collection["Structure"]),
                        Taille = collection["Taille"],
                        ValeurAgilite = int.Parse(collection["ValeurAgilite"]),
                        ValeurArmePrincipale = int.Parse(collection["ValeurArmePrincipale"]),
                        XIDAction = int.Parse(collection["action"])
                    });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vaisseau/Delete/5
        public ActionResult Delete(int id)
        {
            VaisseauRepo AR = new VaisseauRepo();
            Vaisseaux a = new Vaisseaux();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Vaisseau/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Vaisseaux collection)
        {
            try
            {
                VaisseauRepo AR = new VaisseauRepo();
                
                    AR.Delete(id, new Vaisseaux()
                    {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Bouclier = collection.Bouclier,
                        Capacite = collection.Capacite,
                        Energie = collection.Energie,
                        Structure = collection.Structure,
                        Taille = collection.Taille,
                        ValeurAgilite = collection.ValeurAgilite,
                        ValeurArmePrincipale = collection.ValeurArmePrincipale
                    });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}