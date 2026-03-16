using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Indicators.GetAllIndicators
{
    public class GetAllIndicatorsEndpoint : EndpointWithoutRequest<List<GetAllIndicatorsResponse>>
    {
        private readonly IAppDnoRepository _repository;

        public GetAllIndicatorsEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/indicator/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var indicators = await _repository.GetAllIndicatorsAsync(ct);

            var response = indicators.Select(i => new GetAllIndicatorsResponse
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description ?? "",
                Type = i.Type
            }).ToList();

            await Send.OkAsync(response);
        }
    }
}
