using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Users.GetUsers
{
    public class GetUserEndpoint : EndpointWithoutRequest<GetUserResponse>
    {
        private readonly AppDnoDbContext _DbContext;
        public GetUserEndpoint(AppDnoDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/user/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var user = await _DbContext.Users
                .Where(u => u.Id == id)
                .Select(u => new GetUserResponse
                {
                    LastName = u.LastName,
                    Role = u.Role,
                    Group = u.Group,
                    ProjectNumber = u.GetProjectNumber()
                })
                .FirstOrDefaultAsync(ct);
            if (user == null)
            {
                await Send.NotFoundAsync();
                return;
            }
            await Send.OkAsync(user);

        }
    }
}
