using Management.Domain.Entities;
using Management.Service.DTO;
using Management.Service.Helpers;

namespace Management.Service.Interfaces
{
    public interface IDeveloperInterface
    {
        /// crud operators

        public Task<Response<Developer>> CreateAsync(Developer entity);
        public Task<Response<List<Developer>>> GetALlAsync();
        public Task<Response<Developer>> GetByIdAsync(Developer entity);
        public Task<Response<Developer>> UpdateAsync(long OldId, Developer entity);
        public Task<bool> DeleteAsync(long id);

        public Task<Response<MessageDTO>> SendMessage();
        public Task<Response<List<MessageBox>>> WatchAllMessagesOfThePerson(long id);
        public Task<Response<List<TaskDTO>>> WatchMyTaskListAsync();

    }
}
