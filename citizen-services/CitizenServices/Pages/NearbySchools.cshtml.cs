using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenServices.Entities.Database;
using CitizenServices.Entities.Messages;
using CitizenServices.Entities.Services.Saem;
using CitizenServices.Messaging;
using CitizenServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CitizenServices.Pages
{
    public class NearbySchoolsModel : PageModel
    {
        private readonly ILogger<NearbySchoolsModel> _logger;
        private readonly ISaemService _saemService;

        public IList<School> Schools { get; set; }

        [BindProperty]
        public int CitizenPropertyId { get; set; }

        public NearbySchoolsModel(ILogger<NearbySchoolsModel> logger, ISaemService saemService)
        {
            _logger = logger;
            _saemService = saemService;
        }

        public async Task OnGetAsync()
        {
            var schools = await _saemService.GetNearbySchoolsAsync();

            Schools = schools.ToList();
        }
    }
}
