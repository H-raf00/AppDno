using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Suppliers.GetSupplierById
{
    public class GetSupplierByIdEndpoint : EndpointWithoutRequest<GetSupplierByIdResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetSupplierByIdEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/supplier/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var supplier = await _dbContext.Suppliers
                .Where(s => s.Id == id)
                .GroupJoin(
                    _dbContext.Ingredients,
                    s => s.Id,
                    i => i.SupplierId,
                    (supplier, ingredients) => new GetSupplierByIdResponse
                    {
                        Id = supplier.Id,
                        Name = supplier.Name,
                        IngredientsNumber = ingredients.Count()
                    })
                .FirstOrDefaultAsync(ct);

            if (supplier == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            await Send.OkAsync(supplier);
        }
    }
}
