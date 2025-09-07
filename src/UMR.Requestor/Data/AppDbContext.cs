using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using UMR.Requestor.Models;

namespace UMR.Requestor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var projectStatusConverter = new EnumToStringConverter<ProjectStatus>();

            modelBuilder.Entity<Request>()
                .Property(r => r.ProjectStatus)
                .HasConversion(projectStatusConverter);

            base.OnModelCreating(modelBuilder);
        }

        //public void InsertData()
        //{
        //    using (var context = new AppDbContext())
        //    {
        //        var request = new Request
        //        {
        //            ProjectTitle = "Routing logic - change to Medicare Rule",
        //            ProjectStatus = ProjectStatus.Pending,
        //            Description = "Allow claims to route for pricing when Medicare is secondary...",
        //            Reason = "Process improvement...",
        //            PIPP = "PLC11637",
        //            UserStory = "TBD",
        //            ITInstallDate = DateTime.Now,
        //            Ownership = "Capital",
        //            SME = "1",
        //            Notes = "11/13/24 - This is included in a group of initiatives...",
        //            PriorityRanking = "1"
        //        };

        //        context.Add(request);
        //        context.SaveChanges();
        //    }
        //}
    }
}
