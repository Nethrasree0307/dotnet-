using webapi.Model;
using Microsoft.EntityFrameworkCore;

namespace webapi.DB
{
    public class AppDBContext : DbContext
    {
        public  DbSet<Employee> Employees{get;set;}
        public AppDBContext(DbContextOptions<AppDBContext>options)
         : base(options)
         {
          
         }
         protected override void OnModelCreating(ModelBuilder builder)
         {
            base.OnModelCreating(builder);
         }
     }
}