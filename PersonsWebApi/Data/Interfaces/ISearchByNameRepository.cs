using System.Collections.Generic;

namespace PersonsWebApi.Data.Interfaces
{
    /// <summary>Интерфейс содержащий методы для поиска записей из базы данных по имени</summary>
    /// <typeparam name="T">Тип записей в базе данных</typeparam>
    public interface ISearchByNameRepository<T>
    {
        /// <summary>Возвращает запись заданного типа по имени и фамилии</summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <returns>Коллекция объектов заданного типа</returns>
        public IEnumerable<T> GetByFullName(string lastName, string firstName);

        /// <summary>Возвращает коллекцию записей заданного типа по фамилии</summary>
        /// <param name="lastName">Фамилия</param>
        /// <returns>Коллекция объектов заданного типа</returns>
        public IEnumerable<T> GetByLastName(string lastName);

        /// <summary>Возвращает коллекцию записей заданного типа по имени</summary>
        /// <param name="firstName">Имя</param>
        /// <returns>Коллекция объектов заданного типа</returns>
        public IEnumerable<T> GetByFirstName(string firstName);


    }
}
