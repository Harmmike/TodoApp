using TA.Domain.Exceptions;

namespace TA.Domain.Models
{
    /// <summary>
    /// The calendar represents the full application and is used as a basic entry to
    /// create, read, update, and delete Todos.
    /// </summary>
    public class Calendar
    {
        private readonly Schedule _schedule;

        public Calendar(Schedule schedule)
        {
            _schedule = schedule;
        }

        /// <summary>
        /// Returns an IEnumerable of all Todos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Todo> GetAllTodos()
        {
            return _schedule.GetAllTodos();
        }

        /// <summary>
        /// Returns a single Todo based on an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Todo</returns>
        public Todo GetTodoById(Guid id)
        {
            return _schedule.GetTodoById(id);
        }

        /// <summary>
        /// Adds a newly created Todo to the current collection.
        /// </summary>
        /// <param name="todo"></param>
        public void AddTodo(Todo todo)
        {
            _schedule.AddTodo(todo);
        }
    }
}
