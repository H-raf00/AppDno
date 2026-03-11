namespace AppDnoApi.Entities
{
    public class Suppliers
    {
        public string Name { get; set; } = string.Empty;

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
