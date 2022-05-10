using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Thrifty.Areas.Identity.Data;
using Thrifty.Data;

[assembly: HostingStartup(typeof(Thrifty.Areas.Identity.IdentityHostingStartup))]
namespace Thrifty.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ThriftyDataContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ThriftyDataContextConnection")));
            });
        }
    }
}