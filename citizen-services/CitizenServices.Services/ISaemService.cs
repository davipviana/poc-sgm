using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenServices.Entities.Services.Saem;

namespace CitizenServices.Services
{
    public interface ISaemService
    {
        Task<IEnumerable<School>> GetNearbySchoolsAsync();
    }
}