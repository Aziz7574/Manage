using Management.Domain.Entities;
using Management.Domain.Enums;

namespace Management.Service.DTO
{
    public class DeveloperDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StatusOfDeveloper Status { get; set; }
        public decimal Salary { get; set; }
        public SalaryCondition SalaryStatus;
        public List<Topic> Topics { get; set; }
        public List<long> MyContactListAsync { get; set; }
        public string Bio { get; set; }
    }
}
