namespace RateMatch.Mvc.Services
{
    public interface IDataService<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> GetAllAsync(int limit);
        public Task<T?> SingleAsync(int id);
    }
}
