using AppDnoApi.Database;
using AppDnoApi.Entities;
using FastEndpoints;

namespace AppDnoApi.Features.Ingredients.CreateIngredient
{
    public class CreateIngredientEndpoint : Endpoint<CreateIngredientRequest, CreateIngredientResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public CreateIngredientEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Post("/api/ingredient");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateIngredientRequest req, CancellationToken ct)
        {
            var ingredient = new Ingredient
            {
                Name = req.Name,
                SupplierId = req.SupplierId
            };

            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync(ct);

            var response = new CreateIngredientResponse
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                SupplierId = ingredient.SupplierId
            };

            await Send.CreatedAtAsync<CreateIngredientEndpoint>(new { id = ingredient.Id }, response);
        }
    }
}
