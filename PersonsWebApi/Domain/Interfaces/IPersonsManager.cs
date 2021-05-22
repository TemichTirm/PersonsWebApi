using PersonsWebApi.Models;
using PersonsWebApi.Models.DTO;
using System.Collections.Generic;

namespace PersonsWebApi.Domain.Interfaces
{
    /// <summary>Интерфейс обработчика запров поступающих от контроллера</summary>
    public interface IPersonsManager
    {
        /// <summary>Возвращает данные человека по id</summary>
        /// <param name="id">Уникальный идентификационный номер</param>
        /// <returns>Информация о человеке</returns>
        Person GetById(int id);

        /// <summary>Возвращает данные человека по фамилии и имени. Если какой-то из параментов не задан, выдает список людей</summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <returns>Список с данными о найденных людях</returns>
        IEnumerable<Person> GetByName(string lastName, string firstName);

        /// <summary>Возвращает список людей с пагинацией</summary>
        /// <param name="skip">Количество записей которые нужно пропустить от начала</param>
        /// <param name="take">Количество записей, которые нужно выдать</param>
        /// <returns>Список с данными о людях</returns>
        IEnumerable<Person> GetList(int skip, int take);

        /// <summary>Добавляет данные о человеке</summary>
        /// <param name="person">Данные о человеке в формате запроса на создание и изменение</param>
        void Create(PersonCreateAndUpdateRequest person);

        /// <summary>Обновляет данные о человеке</summary>
        /// <param name="id">Id записи, которую нужно обновить</param>
        /// <param name="person">Новые данные о человеке в формате запроса на создание и изменение</param>
        /// <returns>Подтвержнеие выполненеия операции. Если запись по заданному id не найдена, возвразает False</returns>
        bool Update(int id, PersonCreateAndUpdateRequest person);

        /// <summary>Удаляет данные о человеке</summary>
        /// <param name="id">Id записи, которую нужно удалить</param>
        /// <returns>Подтвержнеие выполненеия операции. Если запись по заданному id не найдена, возвразает False</returns>
        bool Delete(int id);
    }
}
