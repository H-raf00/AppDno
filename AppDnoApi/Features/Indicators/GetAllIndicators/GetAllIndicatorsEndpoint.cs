using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Indicators.GetAllIndicators
{
    public class GetAllIndicatorsEndpoint : EndpointWithoutRequest<List<GetAllIndicatorsResponse>>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetAllIndicatorsEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/indicator/all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            List<GetAllIndicatorsResponse> indicators = await _dbContext.Indicators
                .Select(i => new GetAllIndicatorsResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    Type = i.Type
                })
                .ToListAsync(ct);

            await Send.OkAsync(indicators);
        }
    }
}
