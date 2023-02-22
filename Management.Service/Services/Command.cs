using Management.DAL.DataPaths;
using Management.Domain.Entities;
using Management.Service.DTO;
using Management.Service.Helpers;
using Management.Service.Interfaces;
using Newtonsoft.Json;
using System.Reflection;

namespace Management.Service.Services
{
    public class Command : ITask
    {
        private string path = DataPath.Task;

        public Task<Response<TaskDTO>> CancelAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<TaskDTO>> CreateAsync(TaskDTO message)
        {
            try
            {

                Response<List<TaskDTO>> allTasks = await GetAllTasksByIdAsync(message.AssignedToById);

                List<Topic> allDataBase = new List<Topic>();

                allTasks.Result.Add(message);

                foreach (var task in allTasks.Result)
                {
                    allDataBase.Add(new Topic()
                    {
                        Id = task.Id,
                        SenderId = task.GivenByUsertId,
                        SubscriberId = task.GivenByUsertId,
                        Target = task.Target,
                        Status = task.Process,
                        CreatedAt = DateTime.Now
                    });
                }
                string text = JsonConvert.SerializeObject(allDataBase, Formatting.Indented);
                await File.WriteAllTextAsync(path, text);

                var response = new Response<TaskDTO>()
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









        public async Task<Response<List<TaskDTO>>> GetAllTasksByIdAsync(long senderId)
        {
            string Text = await File.ReadAllTextAsync(path);
            if (Text.Length == 0)
            {
                Text = "[]";
                File.WriteAllText(path, Text);
                return null;
            }

            ICollection<Topic> allTasks = JsonConvert.DeserializeObject<ICollection<Topic>>(Text);

            var tasks = allTasks.Where(p => p.SenderId == senderId).ToList();
            Response<List<TaskDTO>> responses = new Response<List<TaskDTO>>();
            foreach (var item in tasks)
            {
                responses.Result.Add(new TaskDTO
                {
                    Id = item.Id,
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

















        public Task<Response<TaskDTO>> UpdateAsync(long id, TaskDTO message)
        {
            throw new NotImplementedException();
        }
    }
}
