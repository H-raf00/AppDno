using AppDnoApi.Entities;

public class GetUserResponse
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public Role Role { get; set; } = 0;
    public string Group { get; set; } = string.Empty;

    public int ProjectNumber { get; set; } = 0;
}
