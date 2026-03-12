using System.ComponentModel.DataAnnotations;

namespace AppDnoApi.Features.Indicators.CreateIndicator
{
    public class CreateIndicatorRequest
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le type est obligatoire.")]
        public string Type { get; set; } = null!;
    }
}
