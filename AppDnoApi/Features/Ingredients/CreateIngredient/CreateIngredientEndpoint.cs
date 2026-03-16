using AppDnoApi.Entities;
using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Ingredients.CreateIngredient
{
    public class CreateIngredientEndpoint : Endpoint<CreateIngredientRequest, CreateIngredientResponse>
    {
        private readonly IAppDnoRepository _repository;

        public CreateIngredientEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
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

            await _repository.CreateIngredientAsync(ingredient, ct);

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
