using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Users.GetUsers;

public class CreateUserEndpoint : EndpointWithoutRequest<List<GetUsersInfoResponse>>
{


    private readonly AppDnoDbContext _DbContext;
    public CreateUserEndpoint(AppDnoDbContext dbContext)
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
        List<GetUsersInfoResponse> users = await _DbContext.Users
            .Select(u => new GetUsersInfoResponse
            {
                LastName = u.LastName,
                Role = u.Role,
                Group = u.Group,
                ProjectNumber = u.GetProjectNumber()
            })
            .ToListAsync(ct);


        Response = users;
    }
}