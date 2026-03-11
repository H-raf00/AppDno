namespace AppDnoApi.Entities
{
    public class Indicator
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Type { get; set; } = null!;
    }
}
