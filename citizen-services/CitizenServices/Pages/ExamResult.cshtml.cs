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
    public class ExamResultModel : PageModel
    {
        private readonly ILogger<ExamResultModel> _logger;
        private readonly ISasciService _sasciService;

        [BindProperty(SupportsGet = true)]
        public string Exam { get; set; }

        public string ExamResult { get; set; }

        public ExamResultModel(ILogger<ExamResultModel> logger, ISasciService sasciService)
        {
            _logger = logger;
            _sasciService = sasciService;
        }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Exam))
            {
                ExamResult = await _sasciService.GetExamResultAsync(Exam);
            }
            else
            {
                ExamResult = "";
            }
        }
    }
}
