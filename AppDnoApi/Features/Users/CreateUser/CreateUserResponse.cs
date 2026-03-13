using AppDnoApi.Entities;

public class CreateUserResponse
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Role Role { get; set; } = 0;
    public string Group { get; set; } = string.Empty;

    public CreateUserResponse(string firstName, string lastName, Role role, string group)
    {
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        Group = group;
    }
}
