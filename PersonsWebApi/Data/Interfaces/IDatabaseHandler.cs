using PersonsWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonsWebApi.Data.Interfaces
{
    public interface IDatabaseHandler<T>
    {
        public Task<IEnumerable<T>> GetData();
        public Task SaveDataCollection(IEnumerable<T> item, bool append);
        public Task SaveDataItem(T item);
    }
}
