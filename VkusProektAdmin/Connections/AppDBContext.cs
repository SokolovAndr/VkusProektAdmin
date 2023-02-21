using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using VkusProektAdmin.Models;

namespace VkusProektAdmin.Connections
{
    public class AppDBContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Order { get; set; }

        public AppDBContext() => Database.Migrate();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=admindb;Trusted_Connection=True;");
        }
    }
}
