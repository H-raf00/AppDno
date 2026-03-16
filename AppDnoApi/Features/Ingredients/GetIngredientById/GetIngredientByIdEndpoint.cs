using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Ingredients.GetIngredientById
{
    public class GetIngredientByIdEndpoint : EndpointWithoutRequest<GetIngredientByIdResponse>
    {
        private readonly IAppDnoRepository _repository;

        public GetIngredientByIdEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/ingredient/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var ingredient = await _repository.GetIngredientByIdAsync(id, ct);

            if (ingredient == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            var response = new GetIngredientByIdResponse
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                SupplierId = ingredient.SupplierId,
                ProjectsNumber = ingredient.Projects?.Count ?? 0
            };

            await Send.OkAsync(response);
        }
    }
}
