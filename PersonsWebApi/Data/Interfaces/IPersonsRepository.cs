using PersonsWebApi.Models;

namespace PersonsWebApi.Data.Interfaces
{
    /// <summary>Интерфейс взаимодействия с базой данных, хранящей записи о людях</summary>
    public interface IPersonsRepository : IReadBaseRepository<Person>, IChangeBaseRepository<Person>, ISearchByNameRepository<Person>
    {
    }
}
