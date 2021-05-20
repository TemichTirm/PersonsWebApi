using PersonsWebApi.Models;
using PersonsWebApi.Models.DTO;
using System.Collections.Generic;

namespace PersonsWebApi.Domain.Interfaces
{
    public interface IPersonsManager
    {
        Person GetById(int id);
        IEnumerable<Person> GetByName(string lastName, string firstName);
        IEnumerable<Person> GetList(int skip, int take);
        void Create(PersonCreateRequest person);
        bool Update(Person person);
        bool Delete(int id);
    }
}
