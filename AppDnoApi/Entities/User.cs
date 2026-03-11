
namespace AppDnoApi.Entities
{
    public enum Role
    {
        ADMIN,
        USER
    }

    public class User
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public Role Role { get; set; } = Role.USER;
        public string Group { get; set; } = null!;

        public List<Project> Projets { get; set; } = new List<Project>();

        public User(string email, string password,string firstName, string lastName, Role role, string group)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Group = group;
        }

        // Parameterless constructor required by EF Core when it can't use constructor binding
        protected User() { }

    }
}

