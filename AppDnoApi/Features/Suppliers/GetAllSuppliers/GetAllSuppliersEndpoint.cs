using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Suppliers.GetAllSuppliers
{
    public class GetAllSuppliersEndpoint : EndpointWithoutRequest<List<GetAllSuppliersResponse>>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetAllSuppliersEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/supplier/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            List<GetAllSuppliersResponse> suppliers = await _dbContext.Suppliers
                .GroupJoin(
                    _dbContext.Ingredients,
                    s => s.Id,
                    i => i.SupplierId,
                    (supplier, ingredients) => new GetAllSuppliersResponse
                    {
                        Id = supplier.Id,
                        Name = supplier.Name,
                        IngredientsNumber = ingredients.Count()
                    })
                .ToListAsync(ct);

            await Send.OkAsync(suppliers);
        }
    }
}
