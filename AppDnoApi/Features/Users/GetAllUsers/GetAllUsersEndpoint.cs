using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Users.GetAllUsers;

public class GetAllUsersEndpoint : EndpointWithoutRequest<List<GetAllUsersResponse>>
{
    private readonly IAppDnoRepository _repository;

    public GetAllUsersEndpoint(IAppDnoRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/api/user/all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = await _repository.GetAllUsersAsync(ct);

        var response = users.Select(user => new GetAllUsersResponse
        {
            Id = user.Id,
            LastName = user.LastName,
            Role = user.Role,
            Group = user.Group,
            ProjectsNumber = user.Projets?.Count ?? 0
        }).ToList();

        await Send.OkAsync(response);
    }
}
