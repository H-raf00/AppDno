using AppDnoApi.Database;
using FastEndpoints;

namespace AppDnoApi.Features.Users.DeleteUser
{
    public class DeleteUserEndpoint : Ep.NoReq.NoRes
    {
        private readonly AppDnoDbContext _DbContext;

        public DeleteUserEndpoint(AppDnoDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public override void Configure()
        {
            Delete("/api/user/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct); // Can be improved?
                return;
            }

            var user = await _DbContext.Users.FindAsync(new object[] { id }, ct);
            if (user is null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }
            _DbContext.Users.Remove(user);
            await _DbContext.SaveChangesAsync(ct);
            await Send.NoContentAsync(ct);
        }
    }
}
