using AppDnoApi.Features.Clients.GetAllClient;
using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Clients.GetClient
{
    public class GetAllClientsEndpoint : EndpointWithoutRequest<List<GetAllClientsResponse>>
    {
        private readonly IAppDnoRepository _repository;

        public GetAllClientsEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/client/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var clients = await _repository.GetAllClientsAsync(ct);

            var response = clients.Select(client => new GetAllClientsResponse
            {
                Id = client.Id,
                Name = client.Name,
                ProjectsNumber = client.Projects?.Count ?? 0
            }).ToList();

            await Send.OkAsync(response);
        }
    }
}

