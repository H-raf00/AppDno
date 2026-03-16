using AppDnoApi.Entities;
using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Clients.CreateClient
{
    public class CreateClientEndpoint : Endpoint<CreateClientRequest, CreateClientResponse>
    {
        private readonly IAppDnoRepository _repository;

        public CreateClientEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Post("/api/client");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateClientRequest req, CancellationToken ct)
        {
            var client = new Client(req.Name);
            await _repository.CreateClientAsync(client, ct);

            var response = new CreateClientResponse
            {
                Id = client.Id,
                Name = client.Name
            };

            await Send.CreatedAtAsync<CreateClientEndpoint>(new { id = client.Id }, response);
        }
    }
}



