using System.ServiceModel;

namespace Wcf_Service.Interfaces
{
    //for_review
    [ServiceContract(Namespace ="http://Microsoft.ServiceModel.Samples", SessionMode = SessionMode.Required, CallbackContract = typeof(IWcf_Callback))]
    public interface IWcf_Servise
    {
        [OperationContract]
        void RunScript();

        [OperationContract]
        void UpdateAndCompile(string path);
    }
}
