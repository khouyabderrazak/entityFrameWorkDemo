using EntityFrameWorkProject.Data;
using EntityFrameWorkProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Tracing;
using System.IO;


// Source: StackOverflow – Resolving the issue of no DbContext instance available during migration.
//https://stackoverflow.com/questions/48363173/how-to-allow-migration-for-a-console-application

namespace EFCore
{
    class Program : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
           
           //var connectionString = "Server=RAB68WZ2H2;Database=mydb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("connectionString");



            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            using (AppDbContext sc = p.CreateDbContext(null))
            {
                sc.Database.Migrate();
            }
        }
    }
}