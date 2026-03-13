using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Users.GetUserById;

public class GetUserByIdEndpoint : EndpointWithoutRequest<GetUserByIdResponse>
{
    private readonly AppDnoDbContext _dbContext;
    
    public GetUserByIdEndpoint(AppDnoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Configure()
    {
        Get("/api/user/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");


        var user = await _dbContext.Users
            .Where(u => u.Id == id)
            .GroupJoin(
                _dbContext.Projects,
                u => u.Id,
                p => p.ClientId,
                (user, projects) => new GetUserByIdResponse
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    Role = user.Role,
                    Group = user.Group,
                    ProjectsNumber = projects.Count()
                })
            .FirstOrDefaultAsync(ct);

        if (user == null)
        {
            await Send.NotFoundAsync();
            return;
        }

        await Send.OkAsync(user);
    }
}
