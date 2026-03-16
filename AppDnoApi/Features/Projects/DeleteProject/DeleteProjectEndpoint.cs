using AppDnoApi.Interface;
using FastEndpoints;

namespace AppDnoApi.Features.Projects.DeleteProject
{
    public class DeleteProjectEndpoint : Ep.NoReq.NoRes
    {
        private readonly IAppDnoRepository _repository;

        public DeleteProjectEndpoint(IAppDnoRepository repository)
        {
            _repository = repository;
        }


        public override void Configure()
        {
            Delete("/api/project/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct);
                return;
            }

            var deleted = await _repository.DeleteProjectAsync(id, ct);
            if (!deleted)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            await Send.NoContentAsync(ct);
        }
    }
}
