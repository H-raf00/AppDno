namespace AppDnoApi.Features.Ingredients.CreateIngredient
{
    public class CreateIngredientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SupplierId { get; set; }
    }
}
