namespace AppDnoApi.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public List<User>? Users { get; set; }

        public int? ResponsableId { get; set; }
        public User? Responsable { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

    }
}
