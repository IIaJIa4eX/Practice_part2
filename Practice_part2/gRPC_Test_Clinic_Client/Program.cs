using Grpc.Net.Client;
using gRPC_Test_Clinic_Namespace;
using System.Transactions;
using static gRPC_Test_Clinic_Namespace.ClinicService;

namespace gRPC_Test_Clinic_Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocetsHttpHandler.Http2UnencryptedSupport", true);


            using var channel = GrpcChannel.ForAddress("http://localhost:5001");

            ClinicServiceClient clinicClient = new(channel);

            var createClientResponse = clinicClient.CreateClient(new CreateClientRequest
            {
                Document = "1111",
                Firstname = "Alex",
                Surname = "B",
            });


            if (createClientResponse.ErrorCode == 0)
            {
                Console.WriteLine($"client created: {createClientResponse.ClientId}");
            }
            else
            {
                Console.WriteLine($"Error message: {createClientResponse.ErrorMessage} error code: {createClientResponse.ErrorCode}");
            }

            var getClients = clinicClient.GetClients(new GetClientsRequest());

            foreach (var cl in getClients.Clients)
            {
                Console.WriteLine($"client id: {cl.ClientId} client name: {cl.Firstname} client document: {cl.Document}");
            }

            Console.ReadKey(true);
        }
    }
}