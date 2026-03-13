namespace AppDnoApi.Entities
{
    public enum IngredientStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public IngredientStatus Status { get; set; } = IngredientStatus.Pending;

        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public List<Project>? Projects { get; set; }

    }
}
