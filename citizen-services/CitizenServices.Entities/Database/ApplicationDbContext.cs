using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CitizenServices.Entities.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CitizenServices.Entities.Database.CitizenProperties> CitizenProperties { get; set; }
        public DbSet<CitizenServices.Entities.Database.CitizenPropertyTypes> CitizenPropertyTypes { get; set; }
    }
}
