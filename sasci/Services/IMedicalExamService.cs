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

        /*[OperationContract]
        MedicalExamResponseModel PingComplexModel(MedicalExamInputModel inputModel);

        [OperationContract]
        void VoidMethod(out string s);

        [OperationContract]
        Task<int> AsyncMethod();

        [OperationContract]
        int? NullableMethod(bool? arg);*/

        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);
    }
}