using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Users.DeleteUser
{
    public class DeleteUserEndpoint : Ep.NoReq.NoRes
    {
        private readonly IAppDnoRepository _repository;

        public DeleteUserEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }


        public override void Configure()
        {
            Delete("/api/user/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct);
                return;
            }

            var deleted = await _repository.DeleteUserAsync(id, ct);
            if (!deleted)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            await Send.NoContentAsync(ct);
        }
    }
}
