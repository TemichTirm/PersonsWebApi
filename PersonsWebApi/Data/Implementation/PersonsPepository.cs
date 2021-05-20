using PersonsWebApi.Data.Interfaces;
using PersonsWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonsWebApi.Data.Implementation
{
    public class PersonsPepository : IPersonsRepository
    {
        private List<Person> _persons;
        private readonly IDatabaseHandler<Person> _databaseHandler;

        public PersonsPepository(IDatabaseHandler<Person> databaseHandler)
        {
            _databaseHandler = databaseHandler;
            _persons = _databaseHandler.GetData().Result?.ToList();
        }
        public IEnumerable<Person> GetAll()
        {
            return _persons;
        }

        public Person GetById(int id)
        {
            return _persons.FirstOrDefault(person => person.Id == id);
        }

        public IEnumerable<Person> GetList(int skip, int take)
        {            
            return _persons.Skip(skip).Take(take);
        }

        public void Create(Person item)
        {
            _persons.Add(item);
        }

        public bool Update(Person item)
        {
            var person = _persons.FirstOrDefault(person => person.Id == item.Id);
            if (person != null)
            { 
                person.Age = item.Age;
                person.Company = item.Company;
                person.Email = item.Email;
                person.FirstName = item.FirstName;
                person.LastName = item.LastName;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var searchResult = _persons.FindIndex(person => person.Id == id);
            if (searchResult >= 0)
            {
                _persons.RemoveAt(searchResult);
                return true;
            }
            return false;
        }

        public Person GetByFullName(string lastName, string firstName)
        {
            return _persons.FirstOrDefault(person => person.LastName == lastName && person.FirstName == firstName);
        }
        public IEnumerable<Person> GetByLastName(string lastName)
        {
            return _persons.FindAll(person => person.LastName == lastName);
        }
        public IEnumerable<Person> GetByFirstName(string firstName)
        {
            return _persons.FindAll(person => person.FirstName == firstName);
        }
    }
}
