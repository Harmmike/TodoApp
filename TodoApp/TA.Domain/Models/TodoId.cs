namespace TA.Domain.Models
{
    public struct TodoId
    {
        public string Id { get; }

        public TodoId(string id)
        {
            Id = id;
        }
    }
}