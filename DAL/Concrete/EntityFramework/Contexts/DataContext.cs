using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework.Contexts
{
    public class DataContext:IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=DESKTOP-LAOJIR7;initial catalog=proje-with-identity;integrated security=true;Encrypt=False");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<History>? Histories { get; set; }
        public DbSet<Book>? Books { get; set; }
    }
}
