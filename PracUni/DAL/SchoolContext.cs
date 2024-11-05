using System;
using System.Collections.Generic;
using System.Data.Entity;
using PracUni.Models;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PracUni.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;")
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}