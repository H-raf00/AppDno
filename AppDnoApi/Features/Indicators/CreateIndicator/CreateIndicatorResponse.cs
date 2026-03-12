namespace AppDnoApi.Features.Indicators.CreateIndicator
{
    public class CreateIndicatorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = null!;
    }
}
