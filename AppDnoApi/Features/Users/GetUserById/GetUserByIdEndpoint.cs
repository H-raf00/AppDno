using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Users.GetUserById;

public class GetUserByIdEndpoint : EndpointWithoutRequest<GetUserByIdResponse>
{
    private readonly IAppDnoRepository _repository;

    public GetUserByIdEndpoint(IAppDnoRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/api/user/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");

        var user = await _repository.GetUserByIdAsync(id, ct);

        if (user == null)
        {
            await Send.NotFoundAsync();
            return;
        }

        var response = new GetUserByIdResponse
        {
            Id = user.Id,
            LastName = user.LastName,
            Role = user.Role,
            Group = user.Group,
            ProjectsNumber = user.Projets?.Count ?? 0
        };

        await Send.OkAsync(response);
    }
}
