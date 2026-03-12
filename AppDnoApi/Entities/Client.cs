namespace AppDnoApi.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Project> Projets { get; set; } = new List<Project>();

        public Client(string name)
        {
            Name = name;
        }

        public int getProjectsNumber()
        {
            return Projets.Count;
        }

    }
}
