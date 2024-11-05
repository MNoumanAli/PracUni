using PracUni.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PracUni.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();
        // GET: Student
        public ActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        public ActionResult Detail(int? id)
        {
            if(id == null) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }
    }
}