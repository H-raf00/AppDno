namespace AppDnoApi.Features.Clients.GetClientById;

public class GetClientByIdResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProjectsNumber { get; set; } = 0;
}
