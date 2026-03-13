using AppDnoApi.Database;
using FastEndpoints;

namespace AppDnoApi.Features.Suppliers.DeleteSupplier
{
    public class DeleteSupplierEndpoint : Ep.NoReq.NoRes
    {
        private readonly AppDnoDbContext _DbContext;

        public DeleteSupplierEndpoint(AppDnoDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public override void Configure()
        {
            Delete("/api/supplier/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct); // Can be improved?
                return;
            }

            var supplier = await _DbContext.Suppliers.FindAsync(new object[] { id }, ct);
            if (supplier is null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }
            // linked to ingredients
            _DbContext.Suppliers.Remove(supplier);
            await _DbContext.SaveChangesAsync(ct);
            await Send.NoContentAsync(ct);
        }
    }
}
