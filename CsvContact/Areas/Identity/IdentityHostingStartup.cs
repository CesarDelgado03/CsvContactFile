using System;
using CsvContact.Areas.Identity.Data;
using CsvContact.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CsvContact.Areas.Identity.IdentityHostingStartup))]
namespace CsvContact.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CsvContactContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CsvContactContextConnection")));

                services.AddDefaultIdentity<CsvContactUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CsvContactContext>();
            });
        }

    }
}