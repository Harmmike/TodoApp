using TA.Domain.Models;

namespace TA.Domain.Services.Providers
{
    public interface ITodoProvider
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo> GetTodoByIdAsync(Guid id);
    }
}
