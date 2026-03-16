using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Suppliers.GetSupplierById
{
    public class GetSupplierByIdEndpoint : EndpointWithoutRequest<GetSupplierByIdResponse>
    {
        private readonly IAppDnoRepository _repository;

        public GetSupplierByIdEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/supplier/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var supplier = await _repository.GetSupplierByIdAsync(id, ct);

            if (supplier == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            var response = new GetSupplierByIdResponse
            {
                Id = supplier.Id,
                Name = supplier.Name,
                IngredientsNumber = supplier.Ingredients?.Count ?? 0
            };

            await Send.OkAsync(response);
        }
    }
}
