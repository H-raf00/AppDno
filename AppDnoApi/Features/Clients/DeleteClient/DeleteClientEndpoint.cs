using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Clients.DeleteClient
{
    public class DeleteClientEndpoint : Ep.NoReq.NoRes
    {
        private readonly IAppDnoRepository _repository;

        public DeleteClientEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }


        public override void Configure()
        {
            Delete("/api/client/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct);
                return;
            }

            var deleted = await _repository.DeleteClientAsync(id, ct);
            if (!deleted)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            await Send.NoContentAsync(ct);
        }
    }
}
