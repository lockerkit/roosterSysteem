﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoosterSysteem.Models;

namespace RoosterSysteem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult EigenGegevens()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            using (ZuydDBEntities db = new ZuydDBEntities())
            {
                ViewBag.Message = "Eigen gegevens";

                var userId = (int) Session["userID"];
                var results = db.UserInfoes.Where(ui => ui.UserUserID == userId).First();
                var model = results;
                return View(model);
            }
        }
        public ActionResult Wijzigen()
            {
            using (ZuydDBEntities db = new ZuydDBEntities())
            {

                db.SaveChanges();
            }
            return RedirectToAction("EigenGegevens", "Home");
        }

        public ActionResult EigenGegevensWijzigen()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Overzicht()
        {
            return View();
        }

        public ActionResult Classroom()
        {
            using (ZuydDBEntities db = new ZuydDBEntities())
            {
                var results = db.Classrooms.First();
                var model = results;
                return View(model);
            }
        }
        public ActionResult Teacher()
        {
            using (ZuydDBEntities db = new ZuydDBEntities())
            {
                var results = db.Teachers.First();
                var model = results;
                return View(model);
            }
        }
        public ActionResult Education()
        {
            using (ZuydDBEntities db = new ZuydDBEntities())
            {
                var results = db.Educations.First();
                var model = results;
                return View(model);
            }
        }
    }
}