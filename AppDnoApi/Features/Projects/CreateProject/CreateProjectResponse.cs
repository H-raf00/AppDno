namespace AppDnoApi.Features.Projects.CreateProject
{
    public class CreateProjectResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int ResponsableId { get; set; }
        public int ClientId { get; set; }
    }
}
