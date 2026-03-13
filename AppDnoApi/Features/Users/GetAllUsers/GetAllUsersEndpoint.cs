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
        var users = await _dbContext.Users
                .GroupJoin(
                    _dbContext.Projects,
                    u => u.Id,
                    p => p.ResponsableId,
                    (user, projects) => new GetAllUsersResponse
                    {
                        Id = user.Id,
                        LastName = user.LastName,
                        Role = user.Role,
                        Group = user.Group,
                        ProjectsNumber = projects.Count()
                    })
                .ToListAsync(ct);


        await Send.OkAsync(users);
    }
}
