using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Users.GetAllUsers;

public class GetAllUsersEndpoint : EndpointWithoutRequest<List<GetAllUsersResponse>>
{
    private readonly AppDnoDbContext _dbContext;
    
    public GetAllUsersEndpoint(AppDnoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Configure()
    {
        Get("/api/user/all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<GetAllUsersResponse> users = await _dbContext.Users
            .Select(u => new GetAllUsersResponse
            {
                Id = u.Id,
                LastName = u.LastName,
                Role = u.Role,
                Group = u.Group,
                ProjectNumber = u.GetProjectNumber()
            })
            .ToListAsync(ct);

        await Send.OkAsync(users);
    }
}
