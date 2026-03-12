using AppDnoApi.Entities;
using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{
    [Required(ErrorMessage = "L'email est obligatoire.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "L'email n'est pas valide.")]
    public string Email { get; set; } = null!;
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.USER;

    //public string? Password { get; set; }


    /*
    public CreateUserRequest(string email, string? password, string? firstName, string? lastName, string? group, Role role)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Group = group;
        Role = role;
    }*/

}
