using AppDnoApi.Entities;

namespace AppDnoApi.Interface
{
    public interface IAppDnoRepository
    {
        // User Operations
        Task<User> CreateUserAsync(User user, CancellationToken ct);
        Task<User?> GetUserByIdAsync(int id, CancellationToken ct);
        Task<List<User>> GetAllUsersAsync(CancellationToken ct);
        Task<bool> DeleteUserAsync(int id, CancellationToken ct);
        Task<User?> UpdateUserAsync(User user, CancellationToken ct);

        // Client Operations
        Task<Client> CreateClientAsync(Client client, CancellationToken ct);
        Task<Client?> GetClientByIdAsync(int id, CancellationToken ct);
        Task<List<Client>> GetAllClientsAsync(CancellationToken ct);
        Task<bool> DeleteClientAsync(int id, CancellationToken ct);

        // Project Operations
        Task<Project> CreateProjectAsync(Project project, CancellationToken ct);
        Task<Project?> GetProjectByIdAsync(int id, CancellationToken ct);
        Task<List<Project>> GetAllProjectsAsync(CancellationToken ct);
        Task<bool> DeleteProjectAsync(int id, CancellationToken ct);

        // Ingredient Operations
        Task<Ingredient> CreateIngredientAsync(Ingredient ingredient, CancellationToken ct);
        Task<Ingredient?> GetIngredientByIdAsync(int id, CancellationToken ct);
        Task<List<Ingredient>> GetAllIngredientsAsync(CancellationToken ct);
        Task<bool> DeleteIngredientAsync(int id, CancellationToken ct);

        // Supplier Operations
        Task<Supplier> CreateSupplierAsync(Supplier supplier, CancellationToken ct);
        Task<Supplier?> GetSupplierByIdAsync(int id, CancellationToken ct);
        Task<List<Supplier>> GetAllSuppliersAsync(CancellationToken ct);
        Task<bool> DeleteSupplierAsync(int id, CancellationToken ct);

        // Indicator Operations
        Task<Indicator> CreateIndicatorAsync(Indicator indicator, CancellationToken ct);
        Task<Indicator?> GetIndicatorByIdAsync(int id, CancellationToken ct);
        Task<List<Indicator>> GetAllIndicatorsAsync(CancellationToken ct);
        Task<bool> DeleteIndicatorAsync(int id, CancellationToken ct);

        // Dashboard Operations
        Task<(int TotalProjects, int TotalClients, int TotalIngredients, int TotalPendingIngredients)> GetDashboardDataAsync(CancellationToken ct);
    }
}
