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

           
            modelBuilder.Entity<Subject>()
                .HasMany(sb => sb.Teachers)
                .WithOne(tch => tch.Subject)
                .HasForeignKey(tch => tch.SubjectId);

            modelBuilder.Entity<Teacher>()
               .HasMany(cl => cl.Classes)
               .WithOne(cl => cl.Teacher)
               .HasForeignKey(cl => cl.TeacherId)
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




            // insert some initial data

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "abderrazzak",
                    LastName = "khouy",
                    StudentNumber = 1222
                }
                );

            modelBuilder.Entity<Subject>().HasData(
                new Subject()
                {
                    Id = 1,
                    Description = "subject discription",
                    Name = "subject 1",
                }
                );

            modelBuilder.Entity<Teacher>().HasData(

                new Teacher()
                {
                    Id = 2,
                    FirstName = "hamzae",
                    LastName = "KHouy",
                    HireDate = DateTime.Now,
                    SubjectId = 1
                }
                );
           }
}
}
