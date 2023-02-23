using Management.Service.DTO;
using Management.Service.Helpers;

namespace Management.Service.Interfaces
{
    public interface IDeveloperInterface
    {
        /// crud operators

        public Task<Response<DeveloperDto>> CreateAsync(DeveloperDto entity);
        public Task<Response<List<DeveloperDto>>> GetALlAsync();
        public Task<Response<DeveloperDto>> GetByIdAsync(DeveloperDto entity);
        public Task<Response<DeveloperDto>> UpdateAsync(long OldId, DeveloperDto entity);
        public Task<bool> DeleteAsync(long id);

        public Task<Response<TaskDTO>> SendMessage(TaskDTO task);
        public Task<Response<List<TaskDTO>>> WatchAllTasksOfThePerson(long id);
        public Task<Response<List<TaskDTO>>> WatchMyTaskListAsync();

    }
}
