using AppDnoApi.Entities;

namespace AppDnoApi.Features.Clients.GetClientById;

public class GetClientByIdResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<ProjectDto> Projects { get; set; } = [];
}

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}