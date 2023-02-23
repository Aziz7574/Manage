using Management.DAL.Repository;
using Management.Domain.Entities;
using Management.Presentation.Developer;
using Management.Service.DTO;
using Management.Service.Services;

namespace MainSpace
{
    public class Program
    {
        static async Task Main()
        {
            Repository<Developer> repository = new Repository<Developer>();


            DeveloperService developerService = new DeveloperService();

            DeveloperDto developerDto = new DeveloperDto()
            {
                Bio = "Az",
                Salary = 20000,
                SalaryStatus = Management.Domain.Enums.SalaryCondition.Paid
            };

            Developer developer = new Developer()
            {
                Id = 12,
                FirstName = "Aziz"
            };
            TaskDTO taskDt0 = new TaskDTO()
            {
                AssignedToById = 12,
                GivenByUsertId = 12,
            };

            var all =  await developerService.GetALlAsync();

            foreach (var item in all.Result)
            {
                Console.WriteLine($"{item.Id}");
            }
          /*  Presentation present = new Presentation();

            present.CreateOrEditProfile();
*/

        }
    }
}