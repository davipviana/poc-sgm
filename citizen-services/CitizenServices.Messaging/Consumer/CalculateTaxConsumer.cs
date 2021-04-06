using System.Threading;
using System.Threading.Tasks;
using CitizenServices.Entities.Messages;

namespace CitizenServices.Messaging.Consumer
{
    public class CalculateTaxConsumer : ITypedConsumer<CalculateTax>
    {
        public Task ConsumeAsync(CalculateTax message, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}