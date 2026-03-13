using AppDnoApi.Database;
using FastEndpoints;

namespace AppDnoApi.Features.Indicators.DeleteIndicator
{
    public class DeleteIndicatorEndpoint : Ep.NoReq.NoRes
    {
        private readonly AppDnoDbContext _DbContext;

        public DeleteIndicatorEndpoint(AppDnoDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public override void Configure()
        {
            Delete("/api/indicator/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct); // Can be improved?
                return;
            }

            var indicator = await _DbContext.Indicators.FindAsync(new object[] { id }, ct);
            if (indicator is null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }
            _DbContext.Indicators.Remove(indicator);
            await _DbContext.SaveChangesAsync(ct);
            await Send.NoContentAsync(ct);
        }
    }
}
