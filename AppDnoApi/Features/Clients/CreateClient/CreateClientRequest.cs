using System.ComponentModel.DataAnnotations;

namespace AppDnoApi.Features.Clients.CreateClient
{
    public class CreateClientRequest
    {
        [Required(ErrorMessage = "L'email est obligatoire.")]
        public string Name { get; set; } = null!;

        public CreateClientRequest(string name)
        {
            Name = name;
        }

    }
}
