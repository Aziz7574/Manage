using Management.Domain.Commons;
using Management.Domain.Enums;

namespace Management.Domain.Entities
{
    public class Developer : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StatusOfDeveloper Status { get; set; }
        public decimal Salary { get; set; }
        public SalaryCondition SalaryStatus { get; set; }
        public List<Topic> Topics { get; set; }
        public List<long> MyContactListAsync { get; set; }
        public string Bio { get; set; }

    }
}
