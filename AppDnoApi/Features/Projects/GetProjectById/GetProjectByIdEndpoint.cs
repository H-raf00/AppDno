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
                .Include(p => p.Responsable)
                .Include(p => p.Client)
                .Where(p => p.Id == id)
                .Select(p => new GetProjectByIdResponse
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
