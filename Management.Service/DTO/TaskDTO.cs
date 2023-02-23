using Management.Domain.Enums;

namespace Management.Service.DTO
{
    public class TaskDTO
    {
        public long GivenByUsertId { get; set; }
        public long AssignedToById { get; set; }
        public string Target { get; set; }
        public TaskCondition Process { get; set; }
    }
}
