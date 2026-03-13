using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Projects.GetProjectById
{
    public class GetProjectByIdEndpoint : EndpointWithoutRequest<GetProjectByIdResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetProjectByIdEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/project/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var project = await _dbContext.Projects
                .Where(p => p.Id == id)
                .GroupJoin(
                    _dbContext.Ingredients,
                    p => p.Id,
                    i => i.Id,
                    (project, ingredients) => new GetProjectByIdResponse
                    {
                        Id = project.Id,
                        Code = project.Code,
                        Name = project.Name,
                        ResponsableId = project.ResponsableId,
                        ClientId = project.ClientId,
                        IngredientsNumber = ingredients.Count()
                    })
                .FirstOrDefaultAsync(ct);

            if (project == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            await Send.OkAsync(project);
        }
    }
}
