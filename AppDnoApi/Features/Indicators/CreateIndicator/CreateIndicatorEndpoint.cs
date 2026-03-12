using AppDnoApi.Database;
using AppDnoApi.Entities;
using FastEndpoints;

namespace AppDnoApi.Features.Indicators.CreateIndicator
{
    public class CreateIndicatorEndpoint : Endpoint<CreateIndicatorRequest, CreateIndicatorResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public CreateIndicatorEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
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

            _dbContext.Indicators.Add(indicator);
            await _dbContext.SaveChangesAsync(ct);

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
