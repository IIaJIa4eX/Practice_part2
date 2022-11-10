using Grpc.Net.Client;
using static ClientServiceProtos.ClientService;
namespace CardClient
{
    //for_review
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.ReadKey(); 

            using (GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5002"))
            {
               ClientServiceClient client = new ClientServiceClient(channel);

                var response = client.GetByEmail(new ClientServiceProtos.GetClientRequest
                {
                    Email = "test@gmail.com",
                });
                Console.WriteLine($"{response.Id} {response.ErrorCode} {response.ErrorMessage}");
            }
        }
    }
}