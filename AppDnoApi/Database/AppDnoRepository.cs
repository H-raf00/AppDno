using Microsoft.EntityFrameworkCore;
using AppDnoApi.Entities;
using AppDnoApi.Interface;

/* GetAll*(*) can be optimised by removing the lists returned with it since they are not used but is it Worth it? Yes*/


namespace AppDnoApi.Database
{
    public sealed class AppDnoRepository(IDbContextFactory<AppDnoDbContext> appdnoDb) : IAppDnoRepository
    {
        readonly IDbContextFactory<AppDnoDbContext> _appdnoDb = appdnoDb;

        #region User Operations

        public async Task<User> CreateUserAsync(User user, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            await db.Users.AddAsync(user, ct);
            await db.SaveChangesAsync(ct);
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Users
                .Include(u => u.Projects)
                .FirstOrDefaultAsync(u => u.Id == id, ct);
        }

        public async Task<List<User>> GetAllUsersAsync(CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Users
                .Include(u => u.Projects)
                .ToListAsync(ct);
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            var user = await db.Users.FindAsync([id], ct);
            if (user is null)
                return false;

            db.Users.Remove(user);
            await db.SaveChangesAsync(ct);
            return true;
        }

        public async Task<User?> UpdateUserAsync(User user, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            db.Users.Update(user);
            await db.SaveChangesAsync(ct);
            return user;
        }

        #endregion

        #region Client Operations

        public async Task<Client> CreateClientAsync(Client client, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            await db.Clients.AddAsync(client, ct);
            await db.SaveChangesAsync(ct);
            return client;
        }

        public async Task<Client?> GetClientByIdAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Clients
                .Include(c => c.Projects)
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<List<Client>> GetAllClientsAsync(CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Clients
                .Include(c => c.Projects)
                .ToListAsync(ct);
        }

        public async Task<bool> DeleteClientAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            var client = await db.Clients.FindAsync([id], ct);
            if (client is null)
                return false;

            db.Clients.Remove(client);
            await db.SaveChangesAsync(ct);
            return true;
        }

        #endregion

        #region Project Operations

        public async Task<Project> CreateProjectAsync(Project project, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            await db.Projects.AddAsync(project, ct);
            await db.SaveChangesAsync(ct);
            return project;
        }

        public async Task<Project?> GetProjectByIdAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Projects
                .Include(p => p.Ingredients)
                .FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task<List<Project>> GetAllProjectsAsync(CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Projects
                .Include(p => p.Ingredients)
                .ToListAsync(ct);
        }

        public async Task<bool> DeleteProjectAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            var project = await db.Projects.FindAsync([id], ct);
            if (project is null)
                return false;

            db.Projects.Remove(project);
            await db.SaveChangesAsync(ct);
            return true;
        }

        #endregion

        #region Ingredient Operations

        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            await db.Ingredients.AddAsync(ingredient, ct);
            await db.SaveChangesAsync(ct);
            return ingredient;
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Ingredients
                .Include(i => i.Projects)
                .FirstOrDefaultAsync(i => i.Id == id, ct);
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync(IngredientStatus status, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Ingredients
                .Include(i => i.Projects)
                .Where(i => i.Status == status)
                .ToListAsync(ct);
        }

        public async Task<bool> DeleteIngredientAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            var ingredient = await db.Ingredients.FindAsync([id], ct);
            if (ingredient is null)
                return false;

            db.Ingredients.Remove(ingredient);
            await db.SaveChangesAsync(ct);
            return true;
        }

        #endregion

        #region Supplier Operations

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            await db.Suppliers.AddAsync(supplier, ct);
            await db.SaveChangesAsync(ct);
            return supplier;
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Suppliers
                .Include(s => s.Ingredients)
                .FirstOrDefaultAsync(s => s.Id == id, ct);
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync(CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Suppliers
                .Include(s => s.Ingredients)
                .ToListAsync(ct);
        }

        public async Task<bool> DeleteSupplierAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            var supplier = await db.Suppliers.FindAsync([id], ct);
            if (supplier is null)
                return false;

            db.Suppliers.Remove(supplier);
            await db.SaveChangesAsync(ct);
            return true;
        }

        #endregion

        #region Indicator Operations

        public async Task<Indicator> CreateIndicatorAsync(Indicator indicator, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            await db.Indicators.AddAsync(indicator, ct);
            await db.SaveChangesAsync(ct);
            return indicator;
        }

        public async Task<Indicator?> GetIndicatorByIdAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Indicators.FindAsync([id], ct);
        }

        public async Task<List<Indicator>> GetAllIndicatorsAsync(CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            return await db.Indicators.ToListAsync(ct);
        }

        public async Task<bool> DeleteIndicatorAsync(int id, CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            var indicator = await db.Indicators.FindAsync([id], ct);
            if (indicator is null)
                return false;

            db.Indicators.Remove(indicator);
            await db.SaveChangesAsync(ct);
            return true;
        }

        #endregion

        #region Dashboard Operations

        public async Task<(int TotalProjects, int TotalClients, int TotalIngredients, int TotalPendingIngredients)> GetDashboardDataAsync(CancellationToken ct)
        {
            using var db = _appdnoDb.CreateDbContext();
            var totalProjects = await db.Projects.CountAsync(ct);
            var totalClients = await db.Clients.CountAsync(ct);
            var totalIngredients = await db.Ingredients.CountAsync(ct);
            var totalPendingIngredients = await db.Ingredients.Where(i => i.Status == Entities.IngredientStatus.Pending).CountAsync(ct);

            return (totalProjects, totalClients, totalIngredients, totalPendingIngredients);
        }

        #endregion
    }
}
