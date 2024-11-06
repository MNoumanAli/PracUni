using PracUni.DAL;
using PracUni.Models;
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

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var student = db.Students.Find(id);
                        var coursesToDelete = student.Enrollments
                                         .Select(e => db.Courses.Find(e.CourseID))
                                         .ToList();

                        db.Courses.RemoveRange(coursesToDelete);
                        db.Enrollments.RemoveRange(student.Enrollments);
                        db.Students.Remove(student);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            } 
            return RedirectToAction("Index");
            
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