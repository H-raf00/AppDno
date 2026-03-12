using AppDnoApi.Database;
using AppDnoApi.Entities;
using FastEndpoints;

namespace AppDnoApi.Features.Suppliers.CreateSupplier
{
    public class CreateSupplierEndpoint : Endpoint<CreateSupplierRequest, CreateSupplierResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public CreateSupplierEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Post("/api/supplier");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateSupplierRequest req, CancellationToken ct)
        {
            var supplier = new Supplier
            {
                Name = req.Name
            };

            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync(ct);

            var response = new CreateSupplierResponse
            {
                Id = supplier.Id,
                Name = supplier.Name
            };

            await Send.CreatedAtAsync<CreateSupplierEndpoint>(new { id = supplier.Id }, response);
        }
    }
}
