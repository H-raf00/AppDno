using AppDnoApi.Database;
using AppDnoApi.Entities;
using AppDnoApi.Features.Users.GetUsers;
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
        var user = new User(req.Email);
        _DbContext.Users.Add(user);
        await _DbContext.SaveChangesAsync(ct);


        var response = new CreateUserResponse
        {
            LastName = user.LastName,
            Role = user.Role,
            Group = user.Group,
            ProjectNumber = user.GetProjectNumber()
        };

        await Send.CreatedAtAsync<CreateUserEndpoint>(new {id = user.Id}, response);
    }
}