namespace Management.DAL.IRepository
{
    public interface IGenericRepository<T>
    {
        public Task<T> CreateAsync(T model);
        public Task<ICollection<T>> GetAllAsync();
        public Task<T> GetByIdAsync(long id);
        public Task<T> UpdateAsync(long oldId, T model);
        public Task<bool> DeleteAsync(long id);
    }
}
