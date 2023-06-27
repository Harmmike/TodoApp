using TA.Domain.Exceptions;
using TA.Domain.Services.Providers;
using TA.Domain.Services.TodoCreators;
using TA.Domain.Services.Validation;

namespace TA.Domain.Models
{
    /// <summary>
    /// The calendar represents the full application and is used as a basic entry to
    /// create, read, update, and delete Todos.
    /// </summary>
    public class Calendar
    {
        private readonly ITodoProvider _todoProvider;
        private readonly ITodoCreator _todoCreator;
        private readonly ITodoIdValidator _todoIdValidator;

        public Calendar(ITodoProvider todoProvider, ITodoCreator todoCreator, ITodoIdValidator todoIdValidator)
        {
            _todoProvider = todoProvider;
            _todoCreator = todoCreator;
            _todoIdValidator = todoIdValidator;
        }

        /// <summary>
        /// Returns an IEnumerable of all Todos.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            return await _todoProvider.GetAllTodosAsync();
        }

        /// <summary>
        /// Returns a single Todo based on an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Todo</returns>
        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            return await _todoProvider.GetTodoByIdAsync(id);
        }

        /// <summary>
        /// Adds a newly created Todo to the current collection.
        /// </summary>
        /// <param name="todo"></param>
        public async Task AddTodoAsync(Todo todo)
        {
            Todo conflictingTodo = await _todoIdValidator.GetConflictingTodo(todo);
            if (conflictingTodo != null)
            {
                throw new ConflictingIdException(conflictingTodo, todo);
            }
            await _todoCreator.CreateTodo(todo);
        }
    }
}
