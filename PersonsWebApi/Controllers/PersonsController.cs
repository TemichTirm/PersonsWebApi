using Microsoft.AspNetCore.Mvc;
using PersonsWebApi.Domain.Interfaces;
using PersonsWebApi.Models;
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

        /// <summary>Возвращает данные человека по имени. Если какой-то из параментов не задан, выдает список людей</summary>
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

        [HttpPost]
        public IActionResult Create([FromBody] PersonCreateRequest person)
        {
            _manager.Create(person);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (_manager.Update(person))
            {
                return Ok();
            }
            return NoContent();
        }

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
