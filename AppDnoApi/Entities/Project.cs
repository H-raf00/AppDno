namespace AppDnoApi.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

    }
}
