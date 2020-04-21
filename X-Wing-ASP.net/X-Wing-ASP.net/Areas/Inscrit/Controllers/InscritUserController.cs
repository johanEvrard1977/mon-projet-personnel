using DAL.Entities;
using DAL.Repository;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_Demo_01.Models;
using X_Wing_ASP.net.Tools;

namespace X_Wing_ASP.net.Areas.Inscrit.Controllers
{
    public class InscritUserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserRepository user = new UserRepository();
            User a = new User();
            a = user.GetByName(Utils.LoginUtilisateur.UserName);
            ViewBag.utilisateur = a;
            return View();
        }

        public ActionResult Login(FormCollection collection)
        {
            UserRepository user = new UserRepository();
            if (ModelState.IsValid)
            {
                
                if (user.Check(collection["username"], collection["psw"]))
                {
                    List<Users> lu = new List<Users>();
                    Utils.LoginUtilisateur = new Users();
                    Utils.LoginUtilisateur.UserName = collection["username"];
                    Utils.LoginUtilisateur.Password = collection["psw"];
                    User a = new User();
                    a = user.GetByName(collection["username"]);
                    if (a.Role == "Admin")
                         return RedirectToAction("../Action/Index");
                    else
                        return RedirectToAction("../Home/Index");
                }
            }
            return Redirect("/");
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                UserRepository AR = new UserRepository();
                if (ModelState.IsValid)
                {
                    AR.Create(new User() {
                        ID = int.Parse(collection["ID"]),
                        Nom = collection["Nom"],
                        UserName = collection["UserName"],
                        Mail = collection["Mail"],
                         Password = collection["Password"],
                        Prenom = collection["Prenom"],
                        Role = collection["Role"]
                    });
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
                AR.Delete(id, new User()
                    {
                        ID = collection.ID,
                        Nom = collection.Nom,
                        UserName = collection.UserName,
                        Collection = collection.Collection,
                        Mail = collection.Mail,
                        Password = collection.Password,
                        Prenom = collection.Prenom,
                        Role = collection.Role
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