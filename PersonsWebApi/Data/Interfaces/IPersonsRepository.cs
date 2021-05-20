using PersonsWebApi.Models;

namespace PersonsWebApi.Data.Interfaces
{
    public interface IPersonsRepository : IReadBaseRepository<Person>, IChangeBaseRepository<Person>, ISearchByNameRepository<Person>
    {
    }
}
