using AppDnoApi.Entities;

public class GetUserResponse
{
    public string LastName { get; set; } = string.Empty;
    public Role Role { get; set; } = 0;
    public string Group { get; set; } = string.Empty;

    public int ProjectNumber { get; set; } = 0;
}
