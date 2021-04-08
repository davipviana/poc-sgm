using System.Threading;
using System.Threading.Tasks;
using CitizenServices.Entities.Database;
using CitizenServices.Entities.Messages;
using Microsoft.EntityFrameworkCore;

namespace CitizenServices.Messaging.Consumer
{
    public class CalculateTaxConsumer : ITypedConsumer<CalculateTax>
    {
        private readonly ApplicationDbContext _dbContext;

        public CalculateTaxConsumer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ConsumeAsync(CalculateTax message, CancellationToken cancellationToken)
        {
            Thread.Sleep(10000);
            double aliquot = 0;
            var property = await _dbContext.CitizenProperties.FirstAsync(cp => cp.CitizenPropertyId == message.PropertyId);

            if (property.MarketValue <= 500000)
            {
                aliquot = 0.7;
            }
            else
            {
                aliquot = 1.5;
            }

            var taxValue = property.MarketValue * aliquot;

            property.TaxValue = taxValue;
            await _dbContext.SaveChangesAsync();
        }
    }
}