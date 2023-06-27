using TA.Domain.Models;

namespace TA.Domain.Services.TodoCreators
{
    public interface ITodoCreator
    {
        Task CreateTodo(Todo todo);
    }
}
