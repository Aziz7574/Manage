using Management.DAL.Repository;
using Management.Domain.Entities;
using System;
namespace MainSpace
{
    public class Program
    {
        static async Task Main()
        {
            Repository<Group> repository = new Repository<Group>();

            Group group = new Group()
            {
                Id = 1,
                Password = "password",
                Login = "Login",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StuffIds = new List<long> { 12, 32, 4 }
            };

            
            await repository.UpdateAsync(12,group);

        }
    }
}