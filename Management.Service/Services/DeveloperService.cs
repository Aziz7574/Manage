using Management.DAL.Repository;
using Management.Domain.Entities;
using Management.Service.DTO;
using Management.Service.Helpers;
using Management.Service.Interfaces;

namespace Management.Service.Services
{
    public class DeveloperService : IDeveloperInterface
    {
        private readonly Repository<Developer> dev = new Repository<Developer>();
        private static long id = 12;



        public async Task<Response<DeveloperDto>> CreateAsync(DeveloperDto entity)
        {
            Response<List<DeveloperDto>> all = await GetALlAsync();

            var obj = all.Result.FirstOrDefault(p => p.Id == entity.Id);

            if (obj is null)
            {
                Developer developer = new Developer()
                {
                    Id = id++,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Bio = entity.Bio
                };
                await dev.CreateAsync(developer);
                Response<DeveloperDto> response = new Response<DeveloperDto>();
                response.Message = "ok";
                response.StatusCode = 200;
                response.Result = entity;
                return response;
            }

            Developer developer1 = new Developer()
            {
                Id = id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Bio = entity.Bio
            };
            await dev.UpdateAsync(obj.Id, developer1);
            Response<DeveloperDto> response1 = new Response<DeveloperDto>();
            response1.Message = "ok";
            response1.StatusCode = 200;
            response1.Result = entity;
            return response1;

        }

        public async Task<bool> DeleteAsync(long id)
        {
            await dev.DeleteAsync(id);
            return true;
        }





        public async Task<Response<List<DeveloperDto>>> GetALlAsync()
        {
            List<Developer> all = await dev.GetAllAsync();
            Response<List<DeveloperDto>> response = new Response<List<DeveloperDto>>();
            if (all != null)
            {
                response.Result = new List<DeveloperDto>();
                foreach (var dev in all)
                {
                    response.Result.Add(new DeveloperDto()
                    {
                        FirstName = dev.FirstName,
                        LastName = dev.LastName,
                        Status = dev.Status,
                        SalaryStatus = dev.SalaryStatus,
                        Salary = dev.Salary,
                        Topics = dev.Topics,
                        MyContactListAsync = dev.MyContactListAsync
                    });
                }

            }
            response.StatusCode = 200;
            response.Message = "OK";
            return response;
        }






        public async Task<Response<DeveloperDto>> GetByIdAsync(DeveloperDto entity)
        {
            List<Developer> all = await dev.GetAllAsync();

            var developer = all.FirstOrDefault(p => p.Id == entity.Id);

            DeveloperDto dto = new DeveloperDto()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Status = entity.Status,
                SalaryStatus = entity.SalaryStatus,
                Salary = entity.Salary,
                Topics = entity.Topics,

            };

            Response<DeveloperDto> response = new Response<DeveloperDto>()
            {
                Message = "OK",
                StatusCode = 200,
                Result = dto
            };
            return response;
        }





        public async Task<Response<DeveloperDto>> UpdateAsync(long OldId, DeveloperDto entity)
        {
            await DeleteAsync(OldId);
            await CreateAsync(entity);
            Response<DeveloperDto> response = new Response<DeveloperDto>()
            {
                Message = "OK",
                StatusCode = 200,
                Result = entity
            };
            return response;
        }



        public async Task<Response<TaskDTO>> SendMessage(TaskDTO task)
        {
            Command command = new Command();

            await command.SendTaskAsync(task);

            Response<TaskDTO> response = new Response<TaskDTO>()
            {
                Message = "OK",
                StatusCode = 200,
                Result = task
            };
            return response;

        }



        public async Task<Response<List<TaskDTO>>> WatchAllTasksOfThePerson(long id)
        {
            Command comand = new Command();
            var all = await comand.GetAllTasksByIdAsync(id);
            Response<List<TaskDTO>> response = new Response<List<TaskDTO>>()
            {
                Message = "OK",
                StatusCode = 200,
                Result = all.Result
            };
            return response;
        }



        public Task<Response<List<TaskDTO>>> WatchMyTaskListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
