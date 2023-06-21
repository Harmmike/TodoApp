using TA.Domain.Common;

namespace TA.Domain.Models
{
    public class Todo : Observable
    {
        public TodoId Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime Created { get; }
        public DateTime Due { get; }
        public bool IsUrgent { get; }
        public bool IsComplete { get; }

        public Todo(TodoId id, string title, string description, DateTime due, bool isUrgent = false, bool isComplete = false)
        {
            Id = id;
            Title = title;
            Description = description;
            Created = DateTime.Now;
            Due = due;
            IsUrgent = isUrgent;
            IsComplete = isComplete;
        }

        /// <summary>
        /// Checks to determine whether the incoming Id conflicts with the Id this Todo uses.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns True if the id conflicts. Returns False if the Id is available.</returns>
        public bool ConflictingId(TodoId id)
        {
            return Id.Id == id.Id;
        }
    }
}
