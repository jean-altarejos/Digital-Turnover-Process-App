using Digital_Turnover_Process_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Digital_Turnover_Process_App.Data
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
