using System.Threading;
using System.Threading.Tasks;
using CitizenServices.Entities.Database;
using CitizenServices.Entities.Messages;

namespace CitizenServices.Messaging.Consumer
{
    public class CalculateTaxConsumer : ITypedConsumer<CalculateTax>
    {
        private readonly ApplicationDbContext _dbContext;

        public CalculateTaxConsumer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ConsumeAsync(CalculateTax message, CancellationToken cancellationToken)
        {
            double aliquot = 0;
            if (message.ProperyValue <= 500000)
            {
                aliquot = 0.7;
            }
            else
            {
                aliquot = 1.5;
            }

            var taxValue = message.ProperyValue * aliquot;

            return Task.CompletedTask;
        }
    }
}