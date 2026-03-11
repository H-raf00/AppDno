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

        // login stuff

    }
}

