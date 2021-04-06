using System.Threading;
using System.Threading.Tasks;

namespace CitizenServices.Messaging
{
    public interface ITypedConsumer<in T>
    {
        Task ConsumeAsync(T message, CancellationToken cancellationToken);
    }
}