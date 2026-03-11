using FastEndpoints;

namespace AppDnoApi.Features.Connexion
{
    public class LoginEndpoint : Ep.Req<UserLoginDTO>.NoRes
    {
        public override void Configure()
        {
            Post("/api/user/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UserLoginDTO req, CancellationToken ct)
        {
            // Votre logique de login ici
            ;
        }
    }
}