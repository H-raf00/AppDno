namespace AppDnoApi.Entities
{
    public enum Role
    {
        ADMIN,
        USER
    }

    public class User
    {
        public int Id { get; set; }
        
        public string Email { get; set; } = null!;
        public string Password { get; set; } = "";

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public Role Role { get; set; } = Role.USER;
        public string Group { get; set; } = "";

        public List<Project> Projets { get; set; } = new List<Project>();

        public User(string email)
        {
            Email = email;
        }

        public User(string email, string firstName, string lastName, Role role)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        protected User() { }

        public int GetProjectNumber()
        {
            return Projets.Count;
        }
    }
}

