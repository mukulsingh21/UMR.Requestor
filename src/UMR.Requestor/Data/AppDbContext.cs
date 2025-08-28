using Microsoft.EntityFrameworkCore;
using UMR.Requestor.Models;

namespace UMR.Requestor.Data
{
    public class AppDbContext : DbContext
    {
        internal object AddRequests;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<AddRequest> Requests { get; set; }
    }
}
    