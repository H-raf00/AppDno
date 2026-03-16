using AppDnoApi.Entities;
using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Projects.CreateProject
{
    public class CreateProjectEndpoint : Endpoint<CreateProjectRequest, CreateProjectResponse>
    {
        private readonly IAppDnoRepository _repository;

        public CreateProjectEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
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
                UserId = req.UserId,
                ClientId = req.ClientId
            };

            await _repository.CreateProjectAsync(project, ct);

            var response = new CreateProjectResponse
            {
                Id = project.Id,
                Code = project.Code,
                Name = project.Name,
                UserId = project.UserId,
                ClientId = project.ClientId
            };

            await Send.CreatedAtAsync<CreateProjectEndpoint>(new { id = project.Id }, response);
        }
    }
}
