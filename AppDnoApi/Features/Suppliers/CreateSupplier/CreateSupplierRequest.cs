using System.ComponentModel.DataAnnotations;

namespace AppDnoApi.Features.Suppliers.CreateSupplier
{
    public class CreateSupplierRequest
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Name { get; set; } = null!;
    }
}
