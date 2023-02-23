using Management.Service.DTO;
using Management.Service.Helpers;

namespace Management.Service.Interfaces
{
    public interface ITask
    {
        public Task<Response<TaskDTO>> SendTaskAsync(TaskDTO message);
        /// <summary>
        /// userId belongs to owner of the profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<Response<List<TaskDTO>>> GetAllTasksByIdAsync(long userId);
        /// <summary>
        /// show conversation with partner of profile
        /// </summary>
        /// <returns></returns>

        public Task<Response<TaskDTO>> GetParticularTaskAsync(long userId, long partnerId);

        //  public Task<Response<TaskDTO>> CancelTaskAsync(long id);
        //  public Task<Response<TaskDTO>> UpdateAsync(long id, TaskDTO message);
    }
}
