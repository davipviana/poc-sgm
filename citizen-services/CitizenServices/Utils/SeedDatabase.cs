using System;
using System.Linq;
using System.Threading.Tasks;
using CitizenServices.Entities.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CitizenServices.Utils
{
    public static class SeedDatabase
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var adminId = await EnsureUser(serviceProvider, testUserPw, "admin@teste.com.br");

                SeedDB(context, adminId);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        public static void SeedDB(ApplicationDbContext context, string userId)
        {
            if (context.CitizenProperties.Any())
            {
                return;   // DB has been seeded
            }

            context.CitizenProperties.AddRange(
                new CitizenProperty
                {
                    Description = "Casa principal",
                    CitizenId = userId,
                    MarketValue = 500000
                },
                new CitizenProperty
                {
                    Description = "Casa do lago",
                    CitizenId = userId,
                    MarketValue = 2000000
                },
                new CitizenProperty
                {
                    Description = "Lote vago",
                    CitizenId = userId,
                    MarketValue = 1500000
                },
                new CitizenProperty
                {
                    Description = "Chácara em condomínio fechado",
                    CitizenId = userId,
                    MarketValue = 8000000
                }
             );
            context.SaveChanges();
        }
    }
}