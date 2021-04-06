using System.Threading;
using System.Threading.Tasks;

namespace CitizenServices.Messaging.Consumer
{
    public class CalculateTaxConsumer : ITypedConsumer<CalculateTax>
    {
        public Task ConsumeAsync(BookCreated message, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}