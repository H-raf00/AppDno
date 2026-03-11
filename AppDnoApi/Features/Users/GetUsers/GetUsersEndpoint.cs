using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Users.GetUsers;

public class GetUsersEndpoint : EndpointWithoutRequest<List<UserInfoResponse>>
{


    private readonly AppDnoDbContext _DbContext;
    public GetUsersEndpoint(AppDnoDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public override void Configure()
    {
        Get("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<UserInfoResponse> users = await _DbContext.Users
            .Select(u => new UserInfoResponse
            {
                Id = u.Id,
                LastName = u.LastName,
                Role = u.Role,
                Group = u.Group
            })
            .ToListAsync(ct);


        Response = users;
    }
}