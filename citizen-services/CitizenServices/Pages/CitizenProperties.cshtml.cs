using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenServices.Entities.Database;
using CitizenServices.Entities.Messages;
using CitizenServices.Messaging;
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
        private readonly MessageProducer _messageProducer;

        public IList<CitizenPropertyModel> CitizenProperties { get; set; }

        [BindProperty]
        public int CitizenPropertyId { get; set; }

        public CitizenPropertiesModel(ILogger<CitizenPropertiesModel> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, MessageProducer messageProducer)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
            _messageProducer = messageProducer;
        }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            await LoadCitizenProperties(userId);
        }

        public async Task<IActionResult> OnPost()
        {
            var userId = _userManager.GetUserId(User);
            var citizenProperty = await _dbContext.CitizenProperties.FirstAsync(cp => cp.CitizenPropertyId == CitizenPropertyId);

            citizenProperty.TaxValue = -1;
            await _dbContext.SaveChangesAsync();
            var @event = new CalculateTax
            {
                PropertyId = CitizenPropertyId
            };

            await _messageProducer.PublishAsync(@event);
            await LoadCitizenProperties(userId);

            return RedirectToPage("./CitizenProperties");
        }

        private async Task LoadCitizenProperties(string userId)
        {
            var citizenProperties = await _dbContext.CitizenProperties.Where(cp => cp.CitizenId == userId).ToListAsync();

            CitizenProperties = citizenProperties.Select(cp => new CitizenPropertyModel
            {
                CitizenPropertyId = cp.CitizenPropertyId,
                Description = cp.Description,
                CitizenId = cp.CitizenId,
                MarketValue = cp.MarketValue,
                FormattedMarketValue = $"R$ {cp.MarketValue.ToString("0.00")}",
                TaxValue = cp.TaxValue == -1 ? null : cp.TaxValue,
                FormattedTaxValue = cp.TaxValue.HasValue && cp.TaxValue != -1 ? $"R$ {cp.TaxValue?.ToString("0.00")}" : "",
                CalculationStatus = GetCalculationStatus(cp.TaxValue)
            }).ToList();
        }

        private string GetCalculationStatus(double? taxValue)
        {
            if (!taxValue.HasValue)
            {
                return "Não calculado";
            }
            else if (taxValue == -1)
            {
                return "Sendo calculado, volte em alguns segundos";
            }
            else
            {
                return "Calculado";
            }
        }

        public class CitizenPropertyModel : CitizenProperty
        {
            public string CalculationStatus { get; set; }
            public string FormattedMarketValue { get; set; }
            public string FormattedTaxValue { get; set; }
        }
    }
}
