using AppDnoApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppDnoApi.Features.Ingredients.CreateIngredient
{
    public class CreateIngredientRequest
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Le fournisseur est obligatoire.")]
        public int SupplierId { get; set; }

        public IngredientStatus Status { get; set; } = IngredientStatus.Pending;
    }
}
