using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Users.GetUsers;

public class GetUsersEndpoint : EndpointWithoutRequest<List<GetUserResponse>>
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
        List<GetUserResponse> users = await _DbContext.Users
            .Select(u => new GetUserResponse
            {
                LastName = u.LastName,
                Role = u.Role,
                Group = u.Group,
                ProjectNumber = u.GetProjectNumber()
            })
            .ToListAsync(ct);

        //Response = users;
        await Send.OkAsync(users);
        
    }
}