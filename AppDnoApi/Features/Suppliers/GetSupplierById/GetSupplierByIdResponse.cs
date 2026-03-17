namespace AppDnoApi.Features.Suppliers.GetSupplierById
{
    public class GetSupplierByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<IngredientDto> Ingredients { get; set; } = [];
    }

    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}


