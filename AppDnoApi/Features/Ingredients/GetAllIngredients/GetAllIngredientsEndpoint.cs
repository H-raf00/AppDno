using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Ingredients.GetAllIngredients
{
    public class GetAllIngredientsEndpoint : EndpointWithoutRequest<List<GetAllIngredientsResponse>>
    {
        private readonly IAppDnoRepository _repository;

        public GetAllIngredientsEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/ingredient/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var ingredients = await _repository.GetAllIngredientsAsync(ct);

            var response = ingredients.Select(ingredient => new GetAllIngredientsResponse
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                SupplierId = ingredient.SupplierId,
                ProjectsNumber = ingredient.Projects?.Count ?? 0
            }).ToList();

            await Send.OkAsync(response);
        }
    }
}
