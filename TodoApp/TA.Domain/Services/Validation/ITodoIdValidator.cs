using TA.Domain.Models;

namespace TA.Domain.Services.Validation
{
    public interface ITodoIdValidator
    {
        Task<Todo> GetConflictingTodo(Todo todo);
    }
}
