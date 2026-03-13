namespace AppDnoApi.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
        
        // ✅ Many-to-Many avec Project
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
