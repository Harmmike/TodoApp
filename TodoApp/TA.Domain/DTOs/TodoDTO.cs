using System.ComponentModel.DataAnnotations;

namespace TA.Domain.DTOs
{
    public class TodoDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Due { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsComplete { get; set; }
    }
}
