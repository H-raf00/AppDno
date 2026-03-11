using System.ComponentModel.DataAnnotations;

namespace AppDnoApi.Features.Connexion
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "L'email est obligatoire.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "L'email doit être dans un format valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Le mot de passe doit contenir entre 4 et 20 caractères.")]
        [RegularExpression(@"^[a-zA-Z0-9&^!@#]+$", ErrorMessage = "Le mot de passe doit contenir uniquement des lettres, des chiffres et les caractères spéciaux &^!@#.")]
        public string Password { get; set; }

        public UserLoginDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
