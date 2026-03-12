using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Ingredients.GetIngredientById
{
    public class GetIngredientByIdEndpoint : EndpointWithoutRequest<GetIngredientByIdResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetIngredientByIdEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/ingredient/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var ingredient = await _dbContext.Ingredients
                .Include(i => i.Supplier)
                .Where(i => i.Id == id)
                .Select(i => new GetIngredientByIdResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    SupplierId = i.SupplierId,
                    SupplierName = i.Supplier.Name,
                    ProjectsNumber = i.Projects.Count
                })
                .FirstOrDefaultAsync(ct);

            if (ingredient == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            await Send.OkAsync(ingredient);
        }
    }
}
