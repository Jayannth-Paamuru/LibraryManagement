using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        //// print hello world 

        //public string Index()
        //{
        //    return "<font color = 'red'>HELLO WORLD!!!</font>";
        //}

        //public string India()
        //{
        //    return "Hello India!!";
        //}

        //Take html from view page
        //public ViewResult Index()  //Viewresult is a type which returns view as a output 
        //{
        //    return View();
        //}

        public ViewResult services()
        {
            return View();

        }

        public ViewResult aboutus()
        {
            return View();
        }

        public string para(int id)
        {
            return "The id you entered is" + id;
        }

        public string twopara(int id, string name, int age)
        {
            return $"Name={name}, ID = {id}, Age = {age}";
        }

        public ContentResult cr()
        {
            return Content("<font color=red><b>Hello World</b></font>","text/html");
        }

        public JavaScriptResult js()
        {
            var a = "alert('welcome to javascript')";
            return JavaScript(a);
        }

        public JsonResult jsn()
        {
            return Json(new {Name="Jayannth",age=22},JsonRequestBehavior.AllowGet);
        }

        public RedirectResult redirecttoothersite()
        {
            return Redirect("https://www.google.co.in/");
        }

        public EmptyResult emty()
        {
            return new EmptyResult();
        }

        public RedirectToRouteResult root()
        {
            return RedirectToAction("Index");
        }

        public HttpNotFoundResult Notfound()
        {
            return new HttpNotFoundResult("WE DIDNOT FIND THAT ACTION SORRY");
        }

        public FileResult GetFile()
        {
            return File(Url.Content("C://c#io/hello.txt"), "text/plain");
        }

        public FileResult testfile()
        {
            string contentType = "application/pdf";
            string filepath = @"C://c#io/hello.pdf";
            return File(filepath,contentType);
        }

        //passing data from controller to view
        public ViewResult Index()  //Viewresult is a type which returns view as a output 
        {
            string occ = "birthday boy";
            int age = 23;
            string name = "Navven";
            ViewData["b"] = occ;
            ViewData["c"] = age;
            ViewData["a"] = name;

            ViewBag.hi = "WELCOME TO MVC";

            TempData["t"] = "LETS ROCK WITH MVC";
            TempData.Keep();
            return View();
        }

        public ViewResult Bang()
        {
            return View();
        }

        [ActionName("HW")]
        public string helloworld()
        {
            return "Hello world method called";
        }

        [ActionName("mp")]
        public ViewResult mypage()
        {
            return View("mypage");
        }
        [NonAction]
        public string hot()
        {
            return "EXAMPLE FOR NONACTION";
        }
        [HttpGet]
        public ViewResult add()
        {
            return View();
        }
        [HttpPost]
        //to read the vales of text boxes
        public ViewResult add(FormCollection f)
        {
            
            int res = int.Parse(f["t1"]) + int.Parse(f["t2"]);
            ViewData["add"] = res;
            
            return View();
        }
    }
}