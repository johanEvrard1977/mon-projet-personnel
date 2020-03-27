using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X_Wing_ASP.net.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserRepository AR = new UserRepository();
            // GET: api/Action
            IEnumerable<User> p = AR.GetAll();

            return View(p);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            UserRepository AR = new UserRepository();
            User a = new User();
            a = AR.GetOne(id);
            return View(a);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User collection)
        {
            try
            {
                UserRepository AR = new UserRepository();
                if (ModelState.IsValid)
                {
                    AR.Create(new User() {
                        ID = collection.ID,
                        Nom = collection.Nom,
                        UserName = collection.UserName,
                        Collection = collection.Collection,
                        Mail = collection.Mail,
                         Password = collection.Password,
                        Prenom = collection.Prenom,
                        Role = collection.Role});
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Use/Edit/5
        public ActionResult Edit(int id)
        {
            UserRepository AR = new UserRepository();
            User a = new User();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User collection)
        {
            try
            {
                UserRepository AR = new UserRepository();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new User() {
                        ID = collection.ID,
                        Nom = collection.Nom,
                        UserName = collection.UserName,
                        Collection = collection.Collection,
                        Mail = collection.Mail,
                        Password = collection.Password,
                        Prenom = collection.Prenom,
                        Role = collection.Role
                    });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            UserRepository AR = new UserRepository();
            User a = new User();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Action/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User collection)
        {
            try
            {
                UserRepository AR = new UserRepository();
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