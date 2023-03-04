using SPADemo.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SPADemo.Controllers
{
    public class HomeController : Controller
    {
        private StudentEntities db = new StudentEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getAllData()
        {
            return Json(db.Students.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult viewData()
        {
            return View();
        }

        public ActionResult inputData()
        {
            return View();
        }

        public ActionResult merData()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult inputData([Bind(Include = "Name,Gender,Birthday")] Student st)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Students.Add(st);
                    db.SaveChanges();
                    return Json(new { success = true, student = st }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}