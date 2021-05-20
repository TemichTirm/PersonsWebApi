using System.Collections.Generic;

namespace PersonsWebApi.Data.Interfaces
{
    public interface ISearchByNameRepository<T>
    {
        public T GetByFullName(string lastName, string firstName);
        public IEnumerable<T> GetByLastName(string lastName);
        public IEnumerable<T> GetByFirstName(string firstName);


    }
}
