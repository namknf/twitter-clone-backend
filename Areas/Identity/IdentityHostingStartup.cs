using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Twitter_backend.Data;

[assembly: HostingStartup(typeof(Twitter_backend.Areas.Identity.IdentityHostingStartup))]

namespace Twitter_backend.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<Twitter_backendContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("twitter_backendContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Twitter_backendContext>();
            });
        }
    }
}