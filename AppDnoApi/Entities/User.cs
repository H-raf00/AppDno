using Microsoft.AspNetCore.Identity;

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

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.USER;
        public string Group { get; set; } = string.Empty;

        public List<Project> Projets { get; set; } = new List<Project>();

        public User(string email, string password, string lastName, Role role, string group)
        {
            Email = email;
            Password = password;
            LastName = lastName;
            Role = role;
            Group = group;
        }

        // Parameterless constructor required by EF Core when it can't use constructor binding
        protected User() { }

    }
}

