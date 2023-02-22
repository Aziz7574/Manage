using Management.DAL.DataPaths;
using Management.DAL.IRepository;
using Management.Domain.Commons;
using Management.Domain.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

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
            if(list != null) { 
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
        public async Task<ICollection<T>> GetAllAsync()
        {
            string Text = await File.ReadAllTextAsync(path);
            if (Text.Length == 0)
            {
                Text = "[]";
                File.WriteAllText(path, Text);
                return null;
            }
            ICollection<T> JText = JsonConvert.DeserializeObject<ICollection<T>>(Text);
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
                List<T> allData = (await GetAllAsync()).ToList();
                T obj = allData.FirstOrDefault(p => p.Id == id);
                return obj;
            }
            catch (Exception ex) { return null; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<T> UpdateAsync(long oldId, T model)
        {
             ICollection<T> all = await GetAllAsync();
            
             List<T> allData = new List<T>();

             if (all != null) { allData = all.ToList();}
             
             T oldObj = await GetByIdAsync(oldId);

            if(oldObj != null)
            {
                long indexOfOldObject = allData.IndexOf(oldObj);
                allData.Remove(oldObj);
                allData.Insert((int)indexOfOldObject,model);
                string json = JsonConvert.SerializeObject(allData, Formatting.Indented);    
                File.WriteAllText(path, json);
                return model;
            }


            allData.Add(model);
            string text = JsonConvert.SerializeObject(allData,Formatting.Indented);
            File.WriteAllText(path, text);  
            return model;
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
                string json = JsonConvert.SerializeObject(allData);
                await File.WriteAllTextAsync(path, json); 
                return true;
            }
        }


    }
}
