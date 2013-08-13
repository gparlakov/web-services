using System.Data.Entity;
using Students.Models;

namespace Students.Data
{
    public class StudentsDb : DbContext
    {
        public StudentsDb()
            :base("StudentsDb")
        {
        }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<School> Schools { get; set; }
        
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

            modelBuilder.Entity<School>().HasKey(s => s.Id).Property(s => s.Name).IsRequired();

            modelBuilder.Entity<Mark>().HasKey(m => m.Id).Property(m => m.Value).IsRequired();            

            base.OnModelCreating(modelBuilder);
        }
    }
}
