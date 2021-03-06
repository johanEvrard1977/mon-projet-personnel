﻿using DAL.Entities;
using DAL.Repository;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X_Wing_ASP.net.Tools;

namespace X_Wing_ASP.net.Areas.Inscrit.Controllers
{
    public class CollectionInscritController : Controller
    {
        // GET: Collection
        public ActionResult Index()
        {
            UserRepository user = new UserRepository();
            User a = new User();
            a = user.GetByName(Utils.LoginUtilisateur.UserName);
            ViewBag.utilisateur = a;
            return View();
        }

        // GET: Collection/Details/5
        public ActionResult Details(int id)
        {
            CollectionRepo AR = new CollectionRepo();
            Collection a = new Collection();
            a = AR.GetOne(id);
            return View(a);
        }

        // GET: Collection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collection/Create
        [HttpPost]
        public ActionResult Create(Collection collection)
        {
            try
            {
                CollectionRepo AR = new CollectionRepo();
                if (ModelState.IsValid)
                {
                    AR.Create(new Collection() {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Amelioration = collection.Amelioration,
                        Escadrons = collection.Escadrons,
                        Pilote = collection.Pilote,
                        Users = collection.Users,
                        Vaisseau = collection.Vaisseau
                        });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Collection/Edit/5
        public ActionResult Edit(int id)
        {
            CollectionRepo AR = new CollectionRepo();
            Collection a = new Collection();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Collection/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Collection collection)
        {
            try
            {
                CollectionRepo AR = new CollectionRepo();
                if (ModelState.IsValid)
                {
                    AR.Update(id, new Collection() {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Amelioration = collection.Amelioration,
                        Escadrons = collection.Escadrons,
                        Pilote = collection.Pilote,
                        Users = collection.Users,
                        Vaisseau = collection.Vaisseau
                    });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Collection/Delete/5
        public ActionResult Delete(int id)
        {
            CollectionRepo AR = new CollectionRepo();
            Collection a = new Collection();
            a = AR.GetOne(id);
            return View(a);
        }

        // POST: Collection/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Collection collection)
        {
            try
            {
                CollectionRepo AR = new CollectionRepo();
                AR.Delete(id, new Collection()
                    {
                        Id = collection.Id,
                        Nom = collection.Nom,
                        Amelioration = collection.Amelioration,
                        Escadrons = collection.Escadrons,
                        Pilote = collection.Pilote,
                        Users = collection.Users,
                        Vaisseau = collection.Vaisseau
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