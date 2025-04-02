using EntityFrameWorkProject.Data;
using EntityFrameWorkProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;



// Source: StackOverflow – Resolving the issue of no DbContext instance available during migration.
//https://stackoverflow.com/questions/48363173/how-to-allow-migration-for-a-console-application

namespace EFCore
{
    class Program : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
           
           var connectionString = "Server=RAB68WZ2H2;Database=mydb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";

            //var configurationBuilder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = configurationBuilder.Build();
            //string connectionString = configuration.GetConnectionString("connectionString");

            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }

        static async Task Main(string[] args)
        {
            Program p = new Program();

            using (AppDbContext sc = p.CreateDbContext(null))
            {
                IUnitOfWork unitOf = new UnitOfWork(sc);

                //writing operations

                await unitOf.SubjectRepository.addOne(new Subject()
                {
                    Name = "some subject",
                    Description = "some description"
                });


                await unitOf.TeacherRepository.addOne(new Teacher()
                {
                    FirstName = "ali",
                    LastName = "khouy",
                    SubjectId = 1,
                    HireDate = DateTime.Now
                });


                await unitOf.StudentRepository.addOne(new Student()
                {
                    FirstName = "saida",
                    LastName = "khouy",
                    StudentNumber = 123
                });

                await unitOf.CLassRepository.addOne(new Class()
                {
                    Description = "class decription",
                    Level = "cp2",
                    Name = "class 1",
                    TeacherId = 2
                });

                await unitOf.CompleteAsyn();

                //reading operations

                List<Teacher> teachers = await unitOf.TeacherReadOnlyRepository.GetAll();

                List<Student> students =await unitOf.StudentReadOnlyRepository.GetAll();

                List<Class> classes =await unitOf.CLassReadOnlyRepository.GetAll();

                List<Subject> subjects =await unitOf.SubjectReadOnlyRepository.GetAll();

                Console.WriteLine($"number of teachers: { teachers.Count() }");
                Console.WriteLine($"number of students: { students.Count() }");
                Console.WriteLine($"number of classes: { classes.Count() }");
                Console.WriteLine($"nomber of subjects: { subjects.Count()}");


                //use stored procedure

                Console.WriteLine("\n_____________________________________________stored procedure_________________________");

                var students2 = sc.Persons
                 .FromSqlRaw("EXEC [GetStudentByStudentNumber] @p0", 1222)
                 .AsEnumerable();

                var student = students2.FirstOrDefault();

                if (student != null)
                {
                    Console.WriteLine(student?.FirstName);
                }
                else
                {
                    Console.WriteLine("No student found.");
                }

                //use teacher_subject_vue

                Console.WriteLine("\n_____________________________________________teacher_subject_vue_______________________________________________________________________");

                var teacherSubjects = sc.V_Teacher_Subjects.ToList();

                foreach (var item in teacherSubjects)
                {
                    Console.WriteLine($"Teacher: {item.FirstName}, Subject: {item.LastName}");
                }

            }

        }
    }
}