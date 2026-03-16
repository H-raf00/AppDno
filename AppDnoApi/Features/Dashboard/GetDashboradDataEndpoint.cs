using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Dashboard
{
    public class GetDashboradDataEndpoint : EndpointWithoutRequest<GetDashboardDataResponse>
    {
        private readonly IAppDnoRepository _repository;

        public GetDashboradDataEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/dashboard");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var (totalProjects, totalClients, totalIngredients, totalPendingIngredients) = 
                await _repository.GetDashboardDataAsync(ct);

            var dashboardData = new GetDashboardDataResponse
            {
                TotalProjects = totalProjects,
                TotalClients = totalClients,
                TotalIngredients = totalIngredients,
                TotalPendingIngredients = totalPendingIngredients
            };

            await Send.OkAsync(dashboardData);
        }
    }
}
