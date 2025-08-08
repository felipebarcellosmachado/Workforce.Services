namespace Workforce.Services
{
    public interface ICrudService<T>
    {
        Task<T> Insert(object dto);
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
        Task<T> Update(object dto);
        Task Delete(int id);
        Task<T> InsertAsync(object dto);
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
        Task<T> UpdateAsync(object dto);
        Task DeleteAsync(int id);

    }
}
