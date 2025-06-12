using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        
        public ViewResult Index()
        {
            int[] data = { 3, 45, 43, 3, 23 };
            ViewBag.Data = data;
            return View();
        }

        public ViewResult Details()
        {
            string[] Names = { "Rohit", "sachin", "Dhoni", "Virat", "Raina" };
            ViewData["key"]=Names;
            return View();
        }
        [HttpGet]
        public ViewResult getnum()
        {
            return View();
        }
        [HttpPost]
        public ViewResult getnum(FormCollection f)
        {
            string name = "jayannth";
            ViewBag.Name = name;    
            
            ViewData["print"] = int.Parse(f["t1"]);
         
            return View();
        }

        [HttpGet]
        public ViewResult greatest()
        {
            return View();
        }
        [HttpPost]
        public ViewResult greatest(FormCollection f)
        {
            ViewBag.num1 = int.Parse(f["t1"]);
            ViewBag.num2 = int.Parse(f["t2"]);
            return View();
        }


        [HttpGet]
        public ViewResult cred()
        {
            return View();
        }
        [HttpPost]
        public ViewResult cred(FormCollection f)
        {
            ViewBag.user = f["user"];
            ViewBag.pass = f["pass"];
            return View();
        }
        //new

        [ActionName("Register")]
        [HttpGet]
        public ViewResult UserRegister()
        {
            return View("UserRegister");
        }
        [ActionName("Register")]
        [HttpPost]
        public ViewResult UserRegister(FormCollection f)
        {
            ViewBag.eid = f["empid"];
            ViewBag.ename = f["empname"];
            ViewBag.dob = f["dob"];
            ViewBag.gender = f["gender"];
            ViewBag.nation = f["nation"];
            return View("UserRegister");
        }
        public ViewResult parameter(string name, int age)
        {
            ViewBag.name = name;
            ViewBag.age = age;
            return View();
        }

    }
}