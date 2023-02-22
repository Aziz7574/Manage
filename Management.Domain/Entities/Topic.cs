using Management.Domain.Commons;
using Management.Domain.Enums;

namespace Management.Domain.Entities
{
    public class Topic : Auditable
    {
        public string Target { get; set; }
        public TaskCondition Status { get; set; }
        public DateTime EstimateOfFinishing { get; set; }
    }
}
