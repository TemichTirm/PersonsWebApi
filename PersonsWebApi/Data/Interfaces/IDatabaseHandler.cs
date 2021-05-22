using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonsWebApi.Data.Interfaces
{
    /// <summary>Интерфейс обработчика базы данных</summary>
    /// <typeparam name="T">Тип записей в базе данных</typeparam>
    public interface IDatabaseHandler<T>
    {
        /// <summary>Возвращает все данные заданного типа из базы данных</summary>
        /// <returns>Коллекция записей заданного типа</returns>
        public Task<IEnumerable<T>> GetData();

        /// <summary>Сохраняет данные заданного типа в базу данных</summary>
        /// <param name="items">Коллекция записей заданного типа</param>
        /// <param name="append">Флаг дозаписи. True - если база данных существует, данные будут добавлены в конец</param>
        public Task SaveDataCollection(IEnumerable<T> items, bool append);

        /// <summary>Сохраняет экземпляр заданного типа в базу данных</summary>
        /// <param name="item">Объект заданного типа</param>
        public Task SaveDataItem(T item);
    }
}
