using AppDnoApi.Database;
using FastEndpoints;

namespace AppDnoApi.Features.Projects.DeleteProject
{
    public class DeleteProjectEndpoint : Ep.NoReq.NoRes
    {
        private readonly AppDnoDbContext _DbContext;

        public DeleteProjectEndpoint(AppDnoDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public override void Configure()
        {
            Delete("/api/project/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct); // Can be improved?
                return;
            }

            var project = await _DbContext.Projects.FindAsync(new object[] { id }, ct);
            if (project is null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }
            _DbContext.Projects.Remove(project);
            await _DbContext.SaveChangesAsync(ct);
            await Send.NoContentAsync(ct);
        }
    }
}
