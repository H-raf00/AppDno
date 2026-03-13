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
                .GroupJoin(
                    _dbContext.Ingredients,
                    p => p.Id,
                    i => i.Id,
                    (project, ingredients) => new GetAllProjectsResponse
                    {
                        Id = project.Id,
                        Code = project.Code,
                        Name = project.Name,
                        ResponsableId = project.ResponsableId,
                        ClientId = project.ClientId,
                        IngredientsNumber = ingredients.Count()
                    })
                .ToListAsync(ct);

            await Send.OkAsync(projects);
        }
    }
}
