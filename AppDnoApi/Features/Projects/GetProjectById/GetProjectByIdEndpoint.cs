using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Projects.GetProjectById
{
    public class GetProjectByIdEndpoint : EndpointWithoutRequest<GetProjectByIdResponse>
    {
        private readonly IAppDnoRepository _repository;

        public GetProjectByIdEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/project/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var project = await _repository.GetProjectByIdAsync(id, ct);

            if (project == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            var response = new GetProjectByIdResponse
            {
                Id = project.Id,
                Code = project.Code,
                Name = project.Name,
                UserId = project.UserId,
                ClientId = project.ClientId,
                IngredientsNumber = project.Ingredients?.Count ?? 0
            };

            await Send.OkAsync(response);
        }
    }
}
