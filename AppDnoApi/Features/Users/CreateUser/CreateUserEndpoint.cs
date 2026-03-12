using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using AppDnoApi.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AppDnoApi.Features.Users.CreateUser;

public class CreateUserEndpoint : Ep.Req<CreateUserRequest>.NoRes
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
    }
}