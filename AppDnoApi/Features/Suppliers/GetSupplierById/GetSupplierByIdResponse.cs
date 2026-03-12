namespace AppDnoApi.Features.Suppliers.GetSupplierById
{
    public class GetSupplierByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int IngredientsNumber { get; set; } = 0;
    }
}
