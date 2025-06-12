using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Controllers;
using LMS.Models;

namespace LMS.Controllers
{
    public class myshopController : Controller
    {
        myshopEntities m = new myshopEntities();   
        // GET: myshop
        public ActionResult Index()
        {
            var res = from t in m.products
                      select t;
            return View(res.ToList());
        }

        [HttpGet]
        public ActionResult GetbyID()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetbyID(FormCollection f)
        {
            string id = f["id"];
            var res = (from t in m.products
                       where t.pid == id
                       select t).FirstOrDefault();
            return View(res);
        }

        [HttpGet]
        public ActionResult delbyID()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delbyid(FormCollection f)
        {
            string id = f["id1"];
            var res = (from t in m.products
                       where t.pid == id
                       select t).FirstOrDefault();
            m.products.Remove(res);
            int i = m.SaveChanges();
            return View(i);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(product f)
        {
            if (ModelState.IsValid)
            {

                m.products.Add(f);
                int i = m.SaveChanges();

                ViewBag.NO = i;
                return View();
            }

            else
            {
                return View();
            }
        }
    }
}