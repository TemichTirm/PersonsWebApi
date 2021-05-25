using Microsoft.AspNetCore.Mvc;
using PersonsWebApi.Domain.Interfaces;
using PersonsWebApi.Models.DTO;
using System.Linq;

namespace PersonsWebApi.Controllers
{
    /// <summary>Контроллер обрабатывающий CRUD запросы http</summary>
    [Route("api/persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsManager _manager;
        /// <summary>Конструктор класса PersonsController</summary>
        /// <param name="manager">Инъектируется сущность реализующая интерфейс IPersonsManager</param>
        public PersonsController(IPersonsManager manager)
        {
            _manager = manager;
        }

        /// <summary>Возвращает данные человека по id</summary>
        /// <param name="id">Уникальный идентификационный номер</param>
        /// <returns>Информация о человеке</returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
                var result = _manager.GetById(id);
                return Ok(result);           
        }

        /// <summary>Возвращает данные человека по фамилии и имени. Если какой-то из параментов не задан, выдает список людей</summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <returns>Список с данными о найденных людях</returns>
        [HttpGet("search")]
        public IActionResult GetByName([FromQuery] string lastName, [FromQuery] string firstName)
        {
            var result = _manager.GetByName(lastName, firstName);
            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>Возвращает список людей с пагинацией</summary>
        /// <param name="skip">Количество записей которые нужно пропустить от начала</param>
        /// <param name="take">Количество записей, которые нужно выдать</param>
        /// <returns>Список с данными о людях</returns>
        [HttpGet]
        public IActionResult GetList([FromQuery] int skip, [FromQuery] int take)
        {
            var result = _manager.GetList(skip, take);
            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>Добавляет данные о человеке</summary>
        /// <param name="person">Данные о человеке в формате запроса на создание и изменение</param>
        /// <returns>Подтверждение выполнения операции</returns>
        [HttpPost]
        public IActionResult Create([FromBody] PersonCreateAndUpdateRequest person)
        {
            _manager.Create(person);
            return Ok();
        }

        /// <summary>Обновляет данные о человеке</summary>
        /// <param name="id">Id записи, которую нужно обновить</param>
        /// <param name="person">Новые данные о человеке в формате запроса на создание и изменение</param>
        /// <returns>Подтвержнеие выполненеия операции. Если запись по заданному id не найдена, возвразает код 204 "No Content"</returns>
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PersonCreateAndUpdateRequest person)
        {
            if (_manager.Update(id, person))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>Удаляет данные о человеке</summary>
        /// <param name="id">Id записи, которую нужно удалить</param>
        /// <returns>Подтвержнеие выполненеия операции. Если запись по заданному id не найдена, возвразает код 204 "No Content"</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_manager.Delete(id))
            {
                return Ok();
            }
            return NoContent();
        }
    }
}
