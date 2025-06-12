using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LMS.Controllers
{
    public class BooksOnlineController : Controller
    {
        LMSDBEntities2 ob = new LMSDBEntities2();
        // GET: BooksOnline
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult Login(Member ob1)
        {
            Session["user"] = ob1.uname;
            string name = (string)Session["user"];
            ViewBag.memberid = ob.Members.Where(x => x.uname == name).Select(x => x.MemberID).FirstOrDefault();
            Session["memberid"] = ViewBag.memberid;
            return RedirectToAction("Products");

        }
        [HttpGet]
        public ActionResult Products()

        {
            var products = ob.Books.ToList();
            if (Session["user"] == null)
                return RedirectToAction("Login");
            return View(products);

        }
        [HttpPost]
        public ActionResult Products(FormCollection f)
        {
            //var data = f["search"].ToLower();

            //var res1 = (from t in ob.Books
            //            where t.Author.Contains(data)
            //            select t).ToList();


            //return View(res1);
            var products = ob.Books.ToList();

            if (f["search"] != null && f["search"] != "")
            {
                string st = f["search"];
                var products1 = ob.Books.Where(x => x.Title.Contains(st)).ToList();
                return View(products1);
            }
            if (Session["user"] == null)
                return RedirectToAction("Login");
            return View(products);



        }
        [HttpGet]
        public ActionResult Buy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buy(FormCollection f)
        {
            if (Session["user"] != null)

            {

                string name = (string)Session["user"];

                ViewBag.memberid = ob.Members.Where(x => x.uname == name).Select(x => x.MemberID).FirstOrDefault();

            }

            BorrowTransaction bt = new BorrowTransaction();
            bt.MemberID = ViewBag.memberid;
            bt.BookID = (int)Session["id"];
            bt.BorrowDate = Convert.ToDateTime( f["BorrowDate"]);
            bt.DueDate = Convert.ToDateTime(f["DueDate"]);
            ob.BorrowTransactions.Add(bt);
            int i = ob.SaveChanges();
            return View();
        }


        [HttpGet]
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(Member m)
        {
            Session["mem"] = m.MemberID;
            if (ModelState.IsValid)
            {
                m.JoinDate = DateTime.Now;
                ob.Members.Add(m);
                int i = ob.SaveChanges();

                ViewBag.NO = i;
                return View();
            }

            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult returndate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult returndate(FormCollection f)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            BorrowTransaction bt = new BorrowTransaction();
            bt.ReturnDate = Convert.ToDateTime(f["rdate"]);
            int mid = (int)Session["memberid"];
            var res = ob.BorrowTransactions.Where(x => x.MemberID == mid).FirstOrDefault();
            res.ReturnDate = Convert.ToDateTime(f["rdate"]);
            if ((int)Convert.ToDateTime(f["rdate"]).Subtract(res.DueDate).TotalDays * 100 > 0)
            {
                res.fine = (int)Convert.ToDateTime(f["rdate"]).Subtract(res.DueDate).TotalDays * 100;
                ViewBag.fine = res.fine;
            }
            else
            {
                res.fine = 0;
                ViewBag.fine = 0;
            }
            ViewBag.duedate = res.DueDate.ToShortDateString();
            ViewBag.rdate = Convert.ToDateTime(f["rdate"]).ToShortDateString();

            ob.BorrowTransactions.AddOrUpdate(res);
            ob.SaveChanges();
            return View();



        }
            
    }
}