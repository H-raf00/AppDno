namespace AppDnoApi.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Ingredient>? Ingredients { get; set; }

    }
}
