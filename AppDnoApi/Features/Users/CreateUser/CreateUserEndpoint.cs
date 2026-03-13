using AppDnoApi.Database;
using AppDnoApi.Entities;
using FastEndpoints;

namespace AppDnoApi.Features.Users.CreateUser;

public class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse>
{
    private readonly AppDnoDbContext _DbContext;
    
    public CreateUserEndpoint(AppDnoDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public override void Configure()
    {
        Post("/api/user");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var user = new User(req.Email, req.FirstName, req.LastName, req.Role, req.Group);
        _DbContext.Users.Add(user);
        await _DbContext.SaveChangesAsync(ct);


        var response = new CreateUserResponse(user.FirstName, user.LastName, user.Role, user.Group);

        await Send.CreatedAtAsync<CreateUserEndpoint>(new {id = user.Id}, response);
    }
}