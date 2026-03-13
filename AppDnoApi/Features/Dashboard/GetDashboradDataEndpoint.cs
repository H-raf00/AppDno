using AppDnoApi.Database;
using AppDnoApi.Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Features.Dashboard
{
    public class GetDashboradDataEndpoint : EndpointWithoutRequest<GetDashboardDataResponse>
    {
        private readonly AppDnoDbContext _dbContext;

        public GetDashboradDataEndpoint(AppDnoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Get("/api/dashboard");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {


            var dashboardData = new GetDashboardDataResponse
            {
                TotalProjects = await _dbContext.Projects.CountAsync(ct),
                TotalClients = await _dbContext.Clients.CountAsync(ct),
                TotalIngredients = await _dbContext.Ingredients.CountAsync(ct),
                TotalPendingIngredients = await _dbContext.Ingredients.Where(i => i.Status == IngredientStatus.Pending).CountAsync(ct)
            };


            if (dashboardData == null)
            {
                await Send.NotFoundAsync();
                return;
            }

            await Send.OkAsync(dashboardData);
        }
    }
}
