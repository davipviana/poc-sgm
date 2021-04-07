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
        public static Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
            }

            return Task.CompletedTask;
        }
    }
}