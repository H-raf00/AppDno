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
                .GroupJoin(
                    _dbContext.Projects,
                    i => i.Id,
                    p => p.Id,
                    (ingredient, projects) => new GetAllIngredientsResponse
                    {
                        Id = ingredient.Id,
                        Name = ingredient.Name,
                        SupplierId = ingredient.SupplierId,
                        ProjectsNumber = projects.Count()
                    })
                .ToListAsync(ct);

            await Send.OkAsync(ingredients);
        }
    }
}
