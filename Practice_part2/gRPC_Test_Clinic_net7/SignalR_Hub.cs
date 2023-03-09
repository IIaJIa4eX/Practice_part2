using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace gRPC_Test_Clinic_net7
{
    [SignalRHub]
    public class SignalR_Hub : Hub
    {
            public async Task SomeMethod(string message, [SignalRHidden] CancellationToken cancellationToken = default)
            {
                await Clients.All.SendAsync(nameof(SomeMethod), message, cancellationToken);
            }

    }
}
