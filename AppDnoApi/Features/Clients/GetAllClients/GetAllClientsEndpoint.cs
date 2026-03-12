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
            List<GetAllClientsResponse> clients = await _dbContext.Clients
                .Select(c => new GetAllClientsResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProjectsNumber = c.getProjectsNumber()
                })
                .ToListAsync(ct);

            await Send.OkAsync(clients);
        }
    }
}

