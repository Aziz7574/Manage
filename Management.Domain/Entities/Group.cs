using Management.Domain.Commons;

namespace Management.Domain.Entities
{
    public class Group : Auditable
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Target { get; set; }
        public List<long> StuffIds { get; set; }
    }
}
