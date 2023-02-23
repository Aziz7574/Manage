using Management.DAL.DataPaths;
using Management.DAL.Repository;
using Management.Domain.Entities;
using Management.Service.DTO;
using Management.Service.Helpers;
using Management.Service.Interfaces;

namespace Management.Service.Services
{
    public class Command : ITask
    {
        private string path = DataPath.Task;
        private static long id = 1;
        private readonly Repository<Topic> repo = new Repository<Topic>();




        public async Task<Response<TaskDTO>> SendTaskAsync(TaskDTO message)
        {
            try
            {

                var existTask = await GetParticularTaskAsync(message.GivenByUsertId, message.AssignedToById);

                if (existTask != null)
                {
                    message.Target = existTask.Result.Target + Environment.NewLine + message.Target;
                    Topic topic = new Topic()
                    {
                        Id = id++,
                        SenderId = message.AssignedToById,
                        SubscriberId = message.AssignedToById,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Target = message.Target
                    };

                    await repo.UpdateAsync(existTask.Result.AssignedToById, topic);
                    await repo.UpdateAsync(existTask.Result.GivenByUsertId, topic);
                    Response<TaskDTO> response1 = new Response<TaskDTO>()
                    {
                        StatusCode = 200,
                        Message = "Great",
                        Result = message

                    };
                    return response1;
                }
                Topic topic1 = new Topic()
                {
                    Id = id++,
                    SenderId = message.AssignedToById,
                    SubscriberId = message.GivenByUsertId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Target = message.Target
                };

                await repo.CreateAsync(topic1);
                await repo.CreateAsync(topic1);
                Response<TaskDTO> response = new Response<TaskDTO>()
                {
                    StatusCode = 200,
                    Message = "Great",
                    Result = message

                };
                return response;
            }
            catch
            {
                return new Response<TaskDTO>
                {
                    StatusCode = 500,
                    Message = "Something went wrong",
                    Result = null
                };
            }
        }









        public async Task<Response<List<TaskDTO>>> GetAllTasksByIdAsync(long ownerOfProfileId)
        {

            List<Topic> allTasks = await repo.GetAllAsync();
            if (allTasks is null) return null;

            var tasks = allTasks.Where(p => p.SenderId == ownerOfProfileId || p.SubscriberId == ownerOfProfileId).ToList();

            Response<List<TaskDTO>> responses = new Response<List<TaskDTO>>();

            foreach (var item in tasks)
            {
                responses.Result.Add(new TaskDTO
                {
                    AssignedToById = item.Id,
                    GivenByUsertId = item.Id,
                    Target = item.Target,
                    Process = item.Status
                });
            }
            responses.StatusCode = 200;
            responses.Message = "Great";
            return responses;
        }




        public async Task<Response<TaskDTO>> GetParticularTaskAsync(long ownerOfProfileId, long partnerId)
        {
            try
            {
                var allTasks = await repo.GetAllAsync();

                var tasks = (allTasks.Where(p => p.SenderId == ownerOfProfileId || p.SubscriberId == ownerOfProfileId).Where(p => p.SubscriberId == partnerId || p.SenderId == partnerId)).ToList();

                Response<TaskDTO> taskDto = new Response<TaskDTO>();

                taskDto.Result = new TaskDTO()
                {
                    AssignedToById = tasks[0].SenderId,
                    GivenByUsertId = tasks[0].SubscriberId,
                    Target = tasks[0].Target,
                    Process = tasks[0].Status
                };

                taskDto.StatusCode = 200;
                taskDto.Message = "Great";
                return taskDto;
            }
            catch
            {
                return null;
            }
        }
    }
}
