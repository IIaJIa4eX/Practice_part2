using Grpc.Core;
using gRPC_Test_Clinic_Namespace;
using gRPC_Test_DataBase_Clinic;
using Microsoft.EntityFrameworkCore;
using static gRPC_Test_Clinic_Namespace.ClinicService;

namespace gRPC_Test_Clinic.Services.Implementation
{
    public class ClinicService : ClinicServiceBase
    {

        private readonly ClinicDataBaseContext _dbContext;



        public ClinicService(ClinicDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<CreateClientResponse> CreateClient(CreateClientRequest request, ServerCallContext context)
        {
            try
            {
                var client = new Client
                {
                    Document = request.Document,
                    FirstName = request.Firstname,
                    SurName = request.Surname
                };

                _dbContext.Clients.Add(client);
                _dbContext.SaveChanges();

                var response = new CreateClientResponse
                {
                    ClientId = client.Id,
                    ErrorCode = 0,
                    ErrorMessage = ""
                };

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var response = new CreateClientResponse
                {
                    ErrorCode = 1,
                    ErrorMessage = $"{ex.Message}"
                };

                return Task.FromResult(response);
            }
        }

        public override Task<GetClientsResponse> GetClients(GetClientsRequest request, ServerCallContext context)
        {
            try
            {
                var response = new GetClientsResponse();

                var clients = _dbContext.Clients.Select(x => new ClientResponse
                {
                    ClientId = x.Id,
                    Document = x.Document,
                    Firstname = x.FirstName,
                    Surname = x.SurName
                }).ToList();

                response.Clients.AddRange(clients);

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var response = new GetClientsResponse
                {
                    ErrorCode = 1,
                    ErrorMessage = $"{ex.Message}"
                };

                return Task.FromResult(response);
            }
        }

    }
}
