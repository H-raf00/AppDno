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
                .Select(s => new GetAllSuppliersResponse
                {
                    Id = s.Id,
                    Name = s.Name,
                    IngredientsNumber = s.Ingredients.Count
                })
                .ToListAsync(ct);

            await Send.OkAsync(suppliers);
        }
    }
}
