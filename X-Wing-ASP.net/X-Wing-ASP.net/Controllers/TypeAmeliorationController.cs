using DAL.Repository;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X_Wing_ASP.net.Controllers
{
    public class TypeAmeliorationController : Controller
    {
        // GET: TypeAmelioration
        public ActionResult Index()
        {
            TypeAmeliorationRepo AR = new TypeAmeliorationRepo();
            // GET: api/Action
            IEnumerable<TypeAmelioration> p = AR.GetAll();

            return View(p);
        }

        // GET: TypeAmelioration/Details/5
        public ActionResult Details(int id)
        {
            TypeAmeliorationRepo AR = new TypeAmeliorationRepo();
            TypeAmelioration a = new TypeAmelioration();
            a = AR.GetOne(id);
            return View(a);
        }

        // GET: TypeAmelioration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeAmelioration/Create
        [HttpPost]
        public ActionResult Create(TypeAmelioration collection)
        {
            try
            {
                TypeAmeliorationRepo AR = new TypeAmeliorationRepo();
                if (ModelState.IsValid)
                {
                    AR.Create(new TypeAmelioration() { Id = collection.Id, Nom = collection.Nom, Amelioration = collection.Amelioration });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeAmelioration/Edit/5
        public ActionResult Edit(int id)
        {
            TypeAmeliorationRepo AR = new TypeAmeliorationRepo();
            TypeAmelioration a = new TypeAmelioration();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: TypeAmelioration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TypeAmelioration collection)
        {
            try
            {
                TypeAmeliorationRepo AR = new TypeAmeliorationRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new TypeAmelioration() { Id = collection.Id, Nom = collection.Nom });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeAmelioration/Delete/5
        public ActionResult Delete(int id)
        {
            TypeAmeliorationRepo AR = new TypeAmeliorationRepo();
            TypeAmelioration a = new TypeAmelioration();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Action/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TypeAmelioration collection)
        {
            try
            {
                TypeAmeliorationRepo AR = new TypeAmeliorationRepo();
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