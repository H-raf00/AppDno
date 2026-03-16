using AppDnoApi.Entities;
using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Suppliers.CreateSupplier
{
    public class CreateSupplierEndpoint : Endpoint<CreateSupplierRequest, CreateSupplierResponse>
    {
        private readonly IAppDnoRepository _repository;

        public CreateSupplierEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Post("/api/supplier");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateSupplierRequest req, CancellationToken ct)
        {
            var supplier = new Supplier
            {
                Name = req.Name
            };

            await _repository.CreateSupplierAsync(supplier, ct);

            var response = new CreateSupplierResponse
            {
                Id = supplier.Id,
                Name = supplier.Name
            };

            await Send.CreatedAtAsync<CreateSupplierEndpoint>(new { id = supplier.Id }, response);
        }
    }
}
