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
    public class CitizenPropertiesCreateModel : PageModel
    {
        private readonly ILogger<CitizenPropertiesCreateModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;


        [BindProperty]
        public CitizenProperty CitizenProperty { get; set; }

        public CitizenPropertiesCreateModel(ILogger<CitizenPropertiesCreateModel> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            CitizenProperty.CitizenId = _userManager.GetUserId(User);
            _dbContext.CitizenProperties.Add(CitizenProperty);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
