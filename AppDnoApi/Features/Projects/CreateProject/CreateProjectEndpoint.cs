using AppDnoApi.Database;
using AppDnoApi.Entities;
using FastEndpoints;

namespace AppDnoApi.Features.Projects.CreateProject
{
    public class CreateProjectEndpoint : Endpoint<CreateProjectRequest, CreateProjectResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public CreateProjectEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Post("/api/project");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateProjectRequest req, CancellationToken ct)
        {
            var project = new Project
            {
                Code = req.Code,
                Name = req.Name,
                ResponsableId = req.ResponsableId,
                ClientId = req.ClientId
            };

            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync(ct);

            var response = new CreateProjectResponse
            {
                Id = project.Id,
                Code = project.Code,
                Name = project.Name,
                ResponsableId = project.ResponsableId,
                ClientId = project.ClientId
            };

            await Send.CreatedAtAsync<CreateProjectEndpoint>(new { id = project.Id }, response);
        }
    }
}
