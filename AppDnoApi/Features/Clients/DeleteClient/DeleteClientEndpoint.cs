using AppDnoApi.Database;
using FastEndpoints;

namespace AppDnoApi.Features.Clients.DeleteClient
{
    public class DeleteClientEndpoint : Ep.NoReq.NoRes
    {
        private readonly AppDnoDbContext _DbContext;

        public DeleteClientEndpoint(AppDnoDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public override void Configure()
        {
            Delete("/api/client/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct); // Can be improved?
                return;
            }

            var client = await _DbContext.Clients.FindAsync(new object[] { id }, ct);
            if (client is null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }
            _DbContext.Clients.Remove(client);
            await _DbContext.SaveChangesAsync(ct);
            await Send.NoContentAsync(ct);
        }
    }
}
