using PersonsWebApi.Models;
using PersonsWebApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsWebApi.Data.Interfaces
{
    public interface IReadBaseRepository<T>
    {
        public T GetById(int id);
        public IEnumerable<T> GetList(int startId, int numOfRecords);
        public IEnumerable<T> GetAll();
    }
}
