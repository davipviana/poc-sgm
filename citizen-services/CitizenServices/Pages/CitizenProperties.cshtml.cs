using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenServices.Entities.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CitizenServices.Pages
{
    public class CitizenPropertiesModel : PageModel
    {
        private readonly ILogger<CitizenPropertiesModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public IList<CitizenProperty> CitizenProperties { get; set; }

        public CitizenPropertiesModel(ILogger<CitizenPropertiesModel> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            CitizenProperties = await _dbContext.CitizenProperties.Where(cp => cp.CitizenId == userId).ToListAsync();
        }
    }
}
