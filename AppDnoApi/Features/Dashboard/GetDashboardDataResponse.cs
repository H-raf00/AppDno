namespace AppDnoApi.Features.Dashboard
{
    public class GetDashboardDataResponse
    {
        public int TotalProjects { get; set; }
        public int TotalClients { get; set; }
        public int TotalIngredients { get; set; }
        public int TotalPendingIngredients { get; set; } = 0;
    }
}
