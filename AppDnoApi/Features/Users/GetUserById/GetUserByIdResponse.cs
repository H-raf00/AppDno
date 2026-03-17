using AppDnoApi.Entities;

namespace AppDnoApi.Features.Users.GetUserById;

public class GetUserByIdResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Role Role { get; set; }
    public string Group { get; set; } = string.Empty;
    public List<ProjectDto> Projects { get; set; } = [];
}

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
