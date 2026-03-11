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
            // pas besoin de le faire pour l'instant.
            ;
        }
    }
}