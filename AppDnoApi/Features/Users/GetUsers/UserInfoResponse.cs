using AppDnoApi.Entities;

public class UserInfoResponse
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public Role Role { get; set; } = 0;
    public string Group { get; set; } = string.Empty;
}
