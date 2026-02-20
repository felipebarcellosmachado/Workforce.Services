namespace Workforce.Services
{
    public interface ICrudService<T>
    {
        Task<T> InsertAsync(object dto);
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
        Task<T> UpdateAsync(object dto);
        Task DeleteAsync(int id);

    }
}
