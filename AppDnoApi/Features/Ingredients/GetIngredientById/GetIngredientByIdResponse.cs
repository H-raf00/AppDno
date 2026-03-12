namespace AppDnoApi.Features.Ingredients.GetIngredientById
{
    public class GetIngredientByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public int ProjectsNumber { get; set; } = 0;
    }
}
