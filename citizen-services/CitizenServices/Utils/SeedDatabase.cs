using System;
using System.Linq;
using System.Threading.Tasks;
using CitizenServices.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CitizenServices.Utils
{
    public static class SeedDatabase
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                await SeedDb(context);
            }
        }

        public static Task SeedDb(ApplicationDbContext context)
        {
            if (context.CitizenPropertyTypes.Any())
            {
                return Task.CompletedTask;
            }

            context.CitizenPropertyTypes.AddRange(
                new CitizenPropertyType
                {
                    Description = "Residential"
                },
                new CitizenPropertyType
                {
                    Description = "Non-Residential"
                }
            );

            return context.SaveChangesAsync();
        }
    }
}