using AppDnoApi.Entities;
using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Indicators.CreateIndicator
{
    public class CreateIndicatorEndpoint : Endpoint<CreateIndicatorRequest, CreateIndicatorResponse>
    {
        private readonly IAppDnoRepository _repository;

        public CreateIndicatorEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Post("/api/indicator");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateIndicatorRequest req, CancellationToken ct)
        {
            var indicator = new Indicator
            {
                Name = req.Name,
                Description = req.Description,
                Type = req.Type
            };

            await _repository.CreateIndicatorAsync(indicator, ct);

            var response = new CreateIndicatorResponse
            {
                Id = indicator.Id,
                Name = indicator.Name,
                Description = indicator.Description,
                Type = indicator.Type
            };

            await Send.CreatedAtAsync<CreateIndicatorEndpoint>(new { id = indicator.Id }, response);
        }
    }
}
