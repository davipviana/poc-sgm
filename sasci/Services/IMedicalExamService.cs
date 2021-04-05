using System.ServiceModel;
using System.Threading.Tasks;
using SASCi.Models;

namespace SASCi.Services
{
    [ServiceContract]
    public interface IMedicalExamService
    {
        [OperationContract]
        string Ping(string s);

        [OperationContract]
        MedicalExamResponseModel PingComplexModel(MedicalExamInputModel inputModel);
    }
}