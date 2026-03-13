namespace AppDnoApi.Features.Projects.GetProjectById
{
    public class GetProjectByIdResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? ResponsableId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public int UsersNumber { get; set; } = 0;
        public int IngredientsNumber { get; set; } = 0;
    }
}
