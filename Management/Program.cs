using Management.DAL.Repository;
using Management.Domain.Entities;
using Management.Service.DTO;
using Management.Service.Services;

namespace MainSpace
{
    public class Program
    {
        static async Task Main()
        {
            Repository<Group> repository = new Repository<Group>();

            TaskDTO tasktDto = new TaskDTO()
            {
                Id = 1,
                GivenByUsertId = 12,
                AssignedToById = 14,
                Target = "Salom"
            };

            Command k = new Command();

            await k.CreateAsync(tasktDto);

        }
    }
}