using PracUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracUni.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student> {
                new Student { FirstName = "Ali", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "John", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2023-08-01") },
                new Student { FirstName = "Arturo", LastName = "Ary", EnrollmentDate = DateTime.Parse("2024-09-02") }
                };
            foreach (var student in students)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3,},
                new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
                new Course{CourseID=1045,Title="Calculus",Credits=4,},
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=4041,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=1050,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1050},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}