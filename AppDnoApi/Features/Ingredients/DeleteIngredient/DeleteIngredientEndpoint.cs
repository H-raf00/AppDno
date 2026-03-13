using AppDnoApi.Database;
using FastEndpoints;

namespace AppDnoApi.Features.Ingredients.DeleteIngredient
{
    public class DeleteIngredientEndpoint : Ep.NoReq.NoRes
    {
        private readonly AppDnoDbContext _DbContext;

        public DeleteIngredientEndpoint(AppDnoDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public override void Configure()
        {
            Delete("/api/ingredient/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            if (!int.TryParse(Route<string>("id"), out var id))
            {
                await Send.StatusCodeAsync(400, ct); // Can be improved?
                return;
            }

            var ingredient = await _DbContext.Ingredients.FindAsync(new object[] { id }, ct);
            if (ingredient is null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }
            _DbContext.Ingredients.Remove(ingredient);
            await _DbContext.SaveChangesAsync(ct);
            await Send.NoContentAsync(ct);
        }
    }
}
