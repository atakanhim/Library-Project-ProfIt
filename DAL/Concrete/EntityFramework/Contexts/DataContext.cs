using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework.Contexts
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=DESKTOP-LAOJIR7;initial catalog=proje-library;integrated security=true");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<History>? Histories { get; set; }
        public DbSet<Book>? Books { get; set; }
    }
}
