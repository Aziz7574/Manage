using Management.Domain.Commons;
using Management.Domain.Enums;

namespace Management.Domain.Entities
{
    public class ProjectManager : Auditable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Project { get; set; }
        public decimal Salary { get; set; }
        public StatusOfDeveloper Status { get; set; }
        public List<long> MyContactListAsync { get; set; }
        public string Bio { get; set; }


    }
}
