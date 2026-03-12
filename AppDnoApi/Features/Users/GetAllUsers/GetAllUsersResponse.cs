using AppDnoApi.Entities;

namespace AppDnoApi.Features.Users.GetAllUsers;

public class GetAllUsersResponse
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public Role Role { get; set; }
    public string Group { get; set; } = string.Empty;
    public int ProjectNumber { get; set; }
}
