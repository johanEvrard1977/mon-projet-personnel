using DAL.Repository;
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
            IEnumerable<Vaisseaux> p = AR.GetAll();

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
            return View();
        }

        // POST: Vaisseau/Create
        [HttpPost]
        public ActionResult Create(Vaisseaux collection)
        {
            try
            {
                VaisseauRepo AR = new VaisseauRepo();
                if (ModelState.IsValid)
                {
                    AR.Create(new Vaisseaux()
                    {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Bouclier = collection.Bouclier,
                        Capacite = collection.Capacite,
                        Action = collection.Action,
                        Camp = collection.Camp,
                        Energie = collection.Energie,
                        Pilote = collection.Pilote,
                        Structure = collection.Structure,
                        Taille = collection.Taille,
                        ValeurAgilite = collection.ValeurAgilite,
                        ValeurArmePrincipale = collection.ValeurArmePrincipale
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
            VaisseauRepo AR = new VaisseauRepo();
            Vaisseaux a = new Vaisseaux();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Vaisseau/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Vaisseaux collection)
        {
            try
            {
                VaisseauRepo AR = new VaisseauRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Vaisseaux()
                    {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Bouclier = collection.Bouclier,
                        Capacite = collection.Capacite,
                        Action = collection.Action,
                        Camp = collection.Camp,
                        Energie = collection.Energie,
                        Pilote = collection.Pilote,
                        Structure = collection.Structure,
                        Taille = collection.Taille,
                        ValeurAgilite = collection.ValeurAgilite,
                        ValeurArmePrincipale = collection.ValeurArmePrincipale
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