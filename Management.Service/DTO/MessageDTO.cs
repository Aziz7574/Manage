namespace Management.Service.DTO
{
    public class MessageDTO
    {
        public long SentByUsertId { get; set; }
        public long AcceptedByUserId { get; set; }
        public string Content { get; set; }
        public DateTime SendedAt { get; set; }
    }
}
