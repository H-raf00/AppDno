using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Indicators.GetIndicatorById
{
    public class GetIndicatorByIdEndpoint : EndpointWithoutRequest<GetIndicatorByIdResponse>
    {
        private readonly IAppDnoRepository _repository;

        public GetIndicatorByIdEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/indicator/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var indicator = await _repository.GetIndicatorByIdAsync(id, ct);

            if (indicator == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            var response = new GetIndicatorByIdResponse
            {
                Id = indicator.Id,
                Name = indicator.Name,
                Description = indicator.Description ?? "",
                Type = indicator.Type
            };

            await Send.OkAsync(response);
        }
    }
}
