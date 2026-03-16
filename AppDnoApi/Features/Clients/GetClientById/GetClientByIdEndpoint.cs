using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Clients.GetClientById;

public class GetClientByIdEndpoint : EndpointWithoutRequest<GetClientByIdResponse>
{
    private readonly IAppDnoRepository _repository;

    public GetClientByIdEndpoint(IAppDnoRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/api/client/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");

        var client = await _repository.GetClientByIdAsync(id, ct);

        if (client == null)
        {
            await Send.NotFoundAsync();
            return;
        }

        var response = new GetClientByIdResponse
        {
            Id = client.Id,
            Name = client.Name,
            ProjectsNumber = client.Projets?.Count ?? 0
        };

        await Send.OkAsync(response);
    }
}