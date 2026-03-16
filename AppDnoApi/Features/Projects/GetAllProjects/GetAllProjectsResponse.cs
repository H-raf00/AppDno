namespace AppDnoApi.Features.Projects.GetAllProjects
{
    public class GetAllProjectsResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public int ClientId { get; set; }
        public int IngredientsNumber { get; set; } = 0;
    }
}
