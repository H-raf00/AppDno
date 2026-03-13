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
                .Where(i => i.Id == id)
                .GroupJoin(
                    _dbContext.Projects,
                    i => i.Id,
                    p => p.Id,
                    (ingredient, projects) => new GetIngredientByIdResponse
                    {
                        Id = ingredient.Id,
                        Name = ingredient.Name,
                        SupplierId = ingredient.SupplierId,
                        ProjectsNumber = projects.Count()
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
