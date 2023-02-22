using Management.DAL.DataPaths;
using Management.Service.DTO;
using Management.Service.Helpers;
using Management.Service.Interfaces;

namespace Management.Service.Services
{
    public class Task : ITask
    {
        private string path = DataPath.Task;

        public System.Threading.Tasks.Task<Response<TaskDTO>> CancelAsync(long id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Response<TaskDTO>> CreateAsync(TaskDTO message)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Response<List<TaskDTO>>> GetAllTasksByIdAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Response<TaskDTO>> UpdateAsync(long id, TaskDTO message)
        {
            throw new NotImplementedException();
        }
    }
}
