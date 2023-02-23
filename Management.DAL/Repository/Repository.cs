using Management.DAL.DataPaths;
using Management.DAL.IRepository;
using Management.Domain.Commons;
using Management.Domain.Entities;
using Newtonsoft.Json;

namespace Management.DAL.Repository
{
    public class Repository<T> : IGenericRepository<T> where T : Auditable
    {
        private readonly string path;
        public Repository()
        {
            if (typeof(T) == typeof(Developer))
                path = DataPath.Developer;
            else if (typeof(T) == typeof(Domain.Entities.Group))
                path = DataPath.Group;
            else if (typeof(T) == typeof(MessageBox))
                path = DataPath.MessageBox;
            else if (typeof(T) == typeof(Topic))
                path = DataPath.Task;
            else if (typeof(T) == typeof(ProjectManager))
                path = DataPath.ProjectManager;
        }


        /// <summary>
        /// creates the model and add it to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<T> CreateAsync(T model)
        {
            ICollection<T> list = await GetAllAsync();
            if (list != null)
            {
                list.Add(model);
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            return model;
        }





        /// <summary>
        /// returns all data of the model
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync()
        {
            string Text = await File.ReadAllTextAsync(path);
            if (Text.Length == 0)
            {
                Text = "[]";
                File.WriteAllText(path, Text);
                return null;
            }
            List<T> JText = JsonConvert.DeserializeObject<List<T>>(Text);
            return JText;
        }



        /// <summary>
        /// returns the model specified by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<T> GetByIdAsync(long id)
        {
            try
            {
                List<T> allData = await GetAllAsync();
                T obj = allData.FirstOrDefault(p => p.Id == id);
                return obj;
            }
            catch { return null; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<T> UpdateAsync(long oldUserId, T model)
        {
            var values = await GetAllAsync();
            var oldUser = values.FirstOrDefault(x => x.Id == oldUserId);
            if (oldUser != null)
            {

                values.Remove(oldUser);
                model.UpdatedAt = DateTime.UtcNow;

                values.Add(model);
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                await File.WriteAllTextAsync(path, json);
                return model;
            }

            return null;


        }





        /// <summary>
        /// deletes the element specified by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<bool> DeleteAsync(long id)
        {
            ICollection<T> allData = await GetAllAsync();
            T obj = allData.FirstOrDefault(p => p.Id == id);
            if (obj == null) return false;
            else
            {
                allData.Remove(obj);
                string json = JsonConvert.SerializeObject(allData, Formatting.Indented);
                await File.WriteAllTextAsync(path, json);
                return true;
            }
        }


    }
}
