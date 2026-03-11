using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Users.GetUsers;

public class GetUsersEndpoint : EndpointWithoutRequest<List<UserInfoResponse>>
{


    public override void Configure()
    {
        Get("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<UserInfoResponse> users = new List<UserInfoResponse>
        {
            new UserInfoResponse
            {
                Id = 1,
                Username = "John Doe",
                Role = "USER",
                Group = "Paris",
            },
            new UserInfoResponse
            {
                Id = 12,
                Username = "John Daaaoe",
                Role = "USEaaaR",
                Group = "Paraaais",
            }
        };


        Response = users;
    }
}