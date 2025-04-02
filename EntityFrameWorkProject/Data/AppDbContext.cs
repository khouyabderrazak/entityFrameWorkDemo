using EntityFrameWorkProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        //public DbSet<Person> Persons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("type")
                .HasValue<Student>("student")
                .HasValue<Teacher>("teacher");

            modelBuilder.Entity<Teacher>()
                .HasOne(tch => tch.Subject)
                .WithOne()
                .HasForeignKey<Teacher>(tch => tch.SubjectId);

            modelBuilder.Entity<Class>()
               .HasOne(cl => cl.Teacher)
               .WithOne()
               .HasForeignKey<Class>(cl => cl.TeacherId)
                ;

            modelBuilder.Entity<Enrollment>()
                 .HasOne(en => en.Class)
                 .WithOne()
                 .HasForeignKey<Enrollment>(en => en.ClassId)
                 .OnDelete(DeleteBehavior.NoAction)
                 ;


            modelBuilder.Entity<Enrollment>()
                 .HasOne(en => en.Person)
                 .WithOne()
                 .HasForeignKey<Enrollment>(en => en.PersonId)
                 .OnDelete(DeleteBehavior.NoAction)
                 ;

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "abderrazzak",
                    LastName = "khouy",
                    StudentNumber = 1222
                }
                );
           }



          
    

    }
}
