using System.ComponentModel.DataAnnotations;

namespace AppDnoApi.Features.Projects.CreateProject
{
    public class CreateProjectRequest
    {
        [Required(ErrorMessage = "Le code est obligatoire.")]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Le responsable est obligatoire.")]
        public int? ResponsableId { get; set; }

        [Required(ErrorMessage = "Le client est obligatoire.")]
        public int ClientId { get; set; }
    }
}
