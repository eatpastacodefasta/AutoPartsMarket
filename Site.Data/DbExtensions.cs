using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Site.Data
{
    public static class DbExtensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<ApplicationContext>();
                    if (context.Database.EnsureCreated())
                    {
                        DbInitializer.Initialize(context);
                    }
                }
            }
        }
    }
}
