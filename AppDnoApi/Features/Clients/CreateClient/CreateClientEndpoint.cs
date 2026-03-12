using AppDnoApi.Database;
using AppDnoApi.Entities;
using AppDnoApi.Features.Users.CreateUser;
using FastEndpoints;

namespace AppDnoApi.Features.Clients.CreateClient
{
    public class CreateClientEndpoint : Endpoint<CreateClientRequest, CreateClientResponse>
    {
        private readonly AppDnoDbContext _DbContext;

        public CreateClientEndpoint(AppDnoDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public override void Configure()
        {
            Post("/api/client");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateClientRequest req, CancellationToken ct)
        {
            var client = new Client(req.Name);
            _DbContext.Clients.Add(client);
            await _DbContext.SaveChangesAsync(ct);


            var response = new CreateClientResponse
            {
                Id = client.Id,
                Name = client.Name
            };

            await Send.CreatedAtAsync<CreateClientEndpoint>(new { id = client.Id }, response);
        }
    }
}



