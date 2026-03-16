using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Suppliers.GetAllSuppliers
{
    public class GetAllSuppliersEndpoint : EndpointWithoutRequest<List<GetAllSuppliersResponse>>
    {
        private readonly IAppDnoRepository _repository;

        public GetAllSuppliersEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/supplier/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var suppliers = await _repository.GetAllSuppliersAsync(ct);

            var response = suppliers.Select(supplier => new GetAllSuppliersResponse
            {
                Id = supplier.Id,
                Name = supplier.Name,
                IngredientsNumber = supplier.Ingredients?.Count ?? 0
            }).ToList();

            await Send.OkAsync(response);
        }
    }
}
