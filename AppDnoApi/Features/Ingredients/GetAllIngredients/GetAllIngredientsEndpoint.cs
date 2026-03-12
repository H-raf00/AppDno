using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Ingredients.GetAllIngredients
{
    public class GetAllIngredientsEndpoint : EndpointWithoutRequest<List<GetAllIngredientsResponse>>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetAllIngredientsEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/ingredient/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            List<GetAllIngredientsResponse> ingredients = await _dbContext.Ingredients
                .Include(i => i.Supplier)
                .Select(i => new GetAllIngredientsResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    SupplierId = i.SupplierId,
                    SupplierName = i.Supplier.Name,
                    ProjectsNumber = i.Projects.Count
                })
                .ToListAsync(ct);

            await Send.OkAsync(ingredients);
        }
    }
}
