using DAL.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Identity;

namespace proje_profit.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<DataContext>();
            });
        }
    }
}
