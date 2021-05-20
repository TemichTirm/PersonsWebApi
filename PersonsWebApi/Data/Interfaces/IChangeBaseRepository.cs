
namespace PersonsWebApi.Data.Interfaces
{
    public interface IChangeBaseRepository<T>
    {
        public void Create(T item);
        public bool Update(T item);
        public bool Delete(int id);
    }
}
