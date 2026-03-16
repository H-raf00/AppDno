using AppDnoApi.Entities;
using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Users.CreateUser;

public class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse>
{
    private readonly IAppDnoRepository _repository;

    public CreateUserEndpoint(IAppDnoRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Post("/api/user");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var user = new User(req.Email, req.FirstName, req.LastName, req.Role, req.Group);
        await _repository.CreateUserAsync(user, ct);

        var response = new CreateUserResponse(user.FirstName, user.LastName, user.Role, user.Group);

        await Send.CreatedAtAsync<CreateUserEndpoint>(new {id = user.Id}, response);
    }
}