using System.Threading.Tasks;

namespace CitizenServices.Services
{
    public interface ISasciService
    {
        Task<string> GetExamResultAsync(string exam);
    }
}