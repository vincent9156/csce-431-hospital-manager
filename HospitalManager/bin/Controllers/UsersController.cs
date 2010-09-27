using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Models;

namespace HospitalManager.Controllers
{
    public class UsersController : Controller
    {
        HospitalManagerDBEntities _db = new HospitalManagerDBEntities();
        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View(_db.USERS.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(USER userToCreate)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    _db.AddToUSERS(userToCreate);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }

                else
                    return View(userToCreate);
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Users/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
