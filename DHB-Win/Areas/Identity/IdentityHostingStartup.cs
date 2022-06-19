using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(DHB_Win.Areas.Identity.IdentityHostingStartup))]

namespace DHB_Win.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}