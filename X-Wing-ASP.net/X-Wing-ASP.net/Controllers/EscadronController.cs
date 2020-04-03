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
    public class EscadronController : Controller
    {
        // GET: Escadron
        public ActionResult Index()
        {
            EscadronRepo AR = new EscadronRepo();
            // GET: api/Action
            IEnumerable<View> p = AR.GetAll();

            return View(p);
        }

        // GET: Escadron/Details/5
        public ActionResult Details(int id)
        {
            EscadronRepo AR = new EscadronRepo();
            Escadron a = new Escadron();
            a = AR.GetOne(id);
            return View(a);
        }

        // GET: Escadron/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escadron/Create
        [HttpPost]
        public ActionResult Create(Escadron collection)
        {
            try
            {
                EscadronRepo AR = new EscadronRepo();
                AR.Create(new Escadron() {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Amelioration = collection.Amelioration,
                        Camp = collection.Camp,
                        Description = collection.Description,
                        Pilote = collection.Pilote,
                        Points = collection.Points,
                        Vaisseau = collection.Vaisseau,
                        Visible = collection.Visible});
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Escadron/Edit/5
        public ActionResult Edit(int id)
        {
            EscadronRepo AR = new EscadronRepo();
            Escadron a = new Escadron();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Escadron/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Escadron collection)
        {
            try
            {
                EscadronRepo AR = new EscadronRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Escadron() {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Amelioration = collection.Amelioration,
                        Camp = collection.Camp,
                        Description = collection.Description,
                        Pilote = collection.Pilote,
                        Points = collection.Points,
                        Vaisseau = collection.Vaisseau,
                        Visible = collection.Visible
                    });
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
            EscadronRepo AR = new EscadronRepo();
            Escadron a = new Escadron();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Action/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Escadron collection)
        {
            try
            {
                EscadronRepo AR = new EscadronRepo();
                if (ModelState.IsValid)
                {
                    AR.Delete(id, new Escadron()
                    {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Amelioration = collection.Amelioration,
                        Camp = collection.Camp,
                        Description = collection.Description,
                        Pilote = collection.Pilote,
                        Points = collection.Points,
                        Vaisseau = collection.Vaisseau,
                        Visible = collection.Visible
                    });
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