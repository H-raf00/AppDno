using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Projects.GetAllProjects
{
    public class GetAllProjectsEndpoint : EndpointWithoutRequest<List<GetAllProjectsResponse>>
    {
        private readonly IAppDnoRepository _repository;

        public GetAllProjectsEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/project/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var projects = await _repository.GetAllProjectsAsync(ct);

            var response = projects.Select(project => new GetAllProjectsResponse
            {
                Id = project.Id,
                Code = project.Code,
                Name = project.Name,
                UserId = project.UserId,
                ClientId = project.ClientId,
                IngredientsNumber = project.Ingredients?.Count ?? 0
            }).ToList();

            await Send.OkAsync(response);
        }
    }
}
