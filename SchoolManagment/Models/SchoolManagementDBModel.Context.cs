using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SchoolManagment.Models
{
    public partial class SchoolManagmentEntities : DbContext
    {
        public SchoolManagmentEntities()
            : base("name=SchoolManagmentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
    }
}
