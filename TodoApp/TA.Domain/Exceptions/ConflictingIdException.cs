using System.Runtime.Serialization;
using TA.Domain.Models;

namespace TA.Domain.Exceptions
{
    /// <summary>
    /// Exception for when a newly created Todo model has an Id that's already being used by an existing Todo item.
    /// </summary>
    public class ConflictingIdException : Exception
    {
        public Todo ExistingTodo { get; }
        public Todo NewTodo { get; }

        public ConflictingIdException(Todo existingTodo, Todo newTodo)
        {
            ExistingTodo = existingTodo;
            NewTodo = newTodo;
        }

        protected ConflictingIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ConflictingIdException(string message, Todo existingTodo, Todo newTodo) : base(message)
        {
            ExistingTodo = existingTodo;
            NewTodo = newTodo;
        }

        public ConflictingIdException(string message, Exception innerException, Todo existingTodo, Todo newTodo) : base(message, innerException)
        {
            ExistingTodo = existingTodo;
            NewTodo = newTodo;
        }
    }
}
