
using System.Collections.Generic;

namespace PersonsWebApi.Data.Interfaces
{
    /// <summary>Интерфейс содержащий методы для получения записей из базы данных</summary>
    /// <typeparam name="T">Тип записей в базе данных</typeparam>
    public interface IReadBaseRepository<T>
    {
        /// <summary>Возвращает запись из базы данных по id</summary>
        /// <param name="id">Уникальный идентификационный номер</param>
        /// <returns>Объект заданного типа</returns>
        public T GetById(int id);

        /// <summary>Возвращает коллекцию записей с пагинацией</summary>
        /// <param name="skip">Количество записей, которые нужно пропустить с начала списка</param>
        /// <param name="take">Количество записей,которые нужно получить</param>
        /// <returns>Коллекция объектов заданного типа</returns>
        public IEnumerable<T> GetList(int skip, int take);

        /// <summary>Возвращает все записи заданного типа</summary>
        /// <returns>Коллекция объектов заданного типа</returns>
        public IEnumerable<T> GetAll();
    }
}
