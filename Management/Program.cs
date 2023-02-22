using Management.DAL.Repository;
using Management.Domain.Entities;
namespace MainSpace
{
    public class Program
    {
        static async Task Main()
        {
            Repository<Group> repository = new Repository<Group>();

            Group group = new Group()
            {
                Id = 211,
                Password = "password",
                Login = "Login",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StuffIds = new List<long> { 12, 32, 4 }
            };


            Console.WriteLine(await repository.UpdateAsync(13, group) == null);

        }
    }
}