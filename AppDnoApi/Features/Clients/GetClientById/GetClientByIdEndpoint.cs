using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Clients.GetClientById;

public class GetClientByIdEndpoint : EndpointWithoutRequest<GetClientByIdResponse>
{
    private readonly AppDnoDbContext _dbContext;
    
    public GetClientByIdEndpoint(AppDnoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Configure()
    {
        Get("/api/client/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");

        var client = await _dbContext.Clients
            .Where(c => c.Id == id)
            .Select(c => new GetClientByIdResponse
            {
                Id = c.Id,
                Name = c.Name,
                ProjectsNumber = c.getProjectsNumber()
            })
            .FirstOrDefaultAsync(ct);

        if (client == null)
        {
            await Send.NotFoundAsync();
            return;
        }

        await Send.OkAsync(client);
    }
}
