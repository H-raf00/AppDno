namespace AppDnoApi.Features.Ingredients.GetAllIngredients
{
    public class GetAllIngredientsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? SupplierId { get; set; }
        public int ProjectsNumber { get; set; } = 0;
    }
}
