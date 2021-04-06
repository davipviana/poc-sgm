using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenServices.Entities.Messages;
using CitizenServices.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CitizenServices.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MessageProducer _messageProducer;

        public IndexModel(ILogger<IndexModel> logger, MessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        public void OnGet()
        {
            var @event = new CalculateTax
            {
            };

            //_messageProducer.PublishAsync(@event).GetAwaiter().GetResult();
        }
    }
}
