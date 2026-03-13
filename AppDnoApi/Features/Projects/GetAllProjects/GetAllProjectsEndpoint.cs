using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Projects.GetAllProjects
{
    public class GetAllProjectsEndpoint : EndpointWithoutRequest<List<GetAllProjectsResponse>>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetAllProjectsEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/project/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            List<GetAllProjectsResponse> projects = await _dbContext.Projects
                .Include(p => p.Responsable)
                .Include(p => p.Client)
                .Select(p => new GetAllProjectsResponse
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    ResponsableId = p.ResponsableId,
                    ClientId = p.ClientId,
                    ClientName = p.Client.Name,
                    UsersNumber = p.Users.Count,
                    IngredientsNumber = p.Ingredients.Count
                })
                .ToListAsync(ct);

            await Send.OkAsync(projects);
        }
    }
}
