namespace Management.Service.DTO
{
    public class TaskDTO
    {
        public long Id { get; set; }
        public long GivenByUsertId { get; set; }
        public long AssignedToById { get; set; }
        public string Tasget { get; set; }
        public DateTime SendedAt { get; set; }
    }
}
