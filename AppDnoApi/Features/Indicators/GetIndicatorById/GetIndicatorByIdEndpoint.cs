using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Indicators.GetIndicatorById
{
    public class GetIndicatorByIdEndpoint : EndpointWithoutRequest<GetIndicatorByIdResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetIndicatorByIdEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/indicator/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int id = Route<int>("id");

            var indicator = await _dbContext.Indicators
                .Where(i => i.Id == id)
                .Select(i => new GetIndicatorByIdResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    Type = i.Type
                })
                .FirstOrDefaultAsync(ct);

            if (indicator == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            await Send.OkAsync(indicator);
        }
    }
}
