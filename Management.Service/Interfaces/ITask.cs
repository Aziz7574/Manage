using Management.Service.DTO;
using Management.Service.Helpers;

namespace Management.Service.Interfaces
{
    public interface ITask
    {
        public Task<Response<TaskDTO>> CreateAsync(TaskDTO message);
        public Task<Response<List<TaskDTO>>> GetAllTasksByIdAsync(long id);
        public Task<Response<TaskDTO>> CancelAsync(long id);
        public Task<Response<TaskDTO>> UpdateAsync(long id, TaskDTO message);
    }
}
