using AppDnoApi.Database;
using AppDnoApi.Features.Clients.GetAllClient;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Clients.GetClient
{
    public class GetAllClientsEndpoint : EndpointWithoutRequest<List<GetAllClientsResponse>>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetAllClientsEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/client/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var clients = await _dbContext.Clients
                .GroupJoin(
                    _dbContext.Projects,
                    c => c.Id,
                    p => p.ClientId,
                    (client, projects) => new GetAllClientsResponse
                    {
                        Id = client.Id,
                        Name = client.Name,
                        ProjectsNumber = projects.Count()
                    })
                .ToListAsync(ct);

            await Send.OkAsync(clients);
        }
    }
}

