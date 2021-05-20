﻿using AutoMapper;
using PersonsWebApi.Data.Interfaces;
using PersonsWebApi.Domain.Interfaces;
using PersonsWebApi.Models;
using PersonsWebApi.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PersonsWebApi.Domain.Implementation
{
    public class PersonsManager : IPersonsManager
    {
        private readonly IPersonsRepository _repository;
        private readonly IMapper _mapper;


        public PersonsManager(IPersonsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(PersonCreateRequest person)
        {
            var lastId = _repository.GetAll().Last().Id;
            var newPersonWithId = _mapper.Map<Person>(person);
            newPersonWithId.Id = ++lastId;
            _repository.Create(newPersonWithId);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Person GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Person> GetByName(string lastName, string firstName)
        {
            if (lastName != null && firstName != null)
            {
                var result = _repository.GetByFullName(lastName, firstName);
                if (result != null)
                {
                    return new List<Person>() { result };
                }
                else return new List<Person>();
            }
            else if (lastName != null)
            {
                return _repository.GetByLastName(lastName);
            }
            else if (firstName != null)
            {
                return _repository.GetByFirstName(firstName);
            }
            return new List<Person>();
        }
        public IEnumerable<Person> GetList(int skip, int take)
        {
            return _repository.GetList(skip, take);
        }

        public bool Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
