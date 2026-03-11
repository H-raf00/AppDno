namespace AppDnoApi.Entities
{
    public class Project
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Responsable { get; set; } = string.Empty;

        public List<User> access { get; set; } = new List<User>();
    }
}
