using System;
using Microsoft.EntityFrameworkCore;
using Systemzarzadzania;
using System.Collections.Generic;
using System.Text;

namespace Systemzarzadzania
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MagazynDB;Trusted_Connection=True;");
        }
}
}
