namespace AppDnoApi.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public int ResponsableId { get; set; }
        public User Responsable { get; set; } = null!;
        
        public List<User> Users { get; set; } = new List<User>();

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
