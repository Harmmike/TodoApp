using TA.Domain.Exceptions;

namespace TA.Domain.Models
{
    public class Schedule
    {
        private readonly List<Todo> _todos;

        public Schedule(List<Todo> todos)
        {
            _todos = todos;
        }

        /// <summary>
        /// Returns an IEnumerable of all Todos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Todo> GetAllTodos()
        {
            return _todos;
        }

        /// <summary>
        /// Returns a single Todo based on an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Todo</returns>
        public Todo GetTodoById(TodoId id)
        {
            return _todos.FirstOrDefault(todo => todo.Id.Id == id.Id);
        }

        /// <summary>
        /// Adds a newly created Todo to the current collection.
        /// </summary>
        /// <param name="todo"></param>
        public void AddTodo(Todo todo)
        {
            foreach (var item in _todos)
            {
                if (item.ConflictingId(todo.Id))
                {
                    throw new ConflictingIdException(item, todo);
                }
            }
            _todos.Add(todo);
        }
    }
}
