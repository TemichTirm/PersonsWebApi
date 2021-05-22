
namespace PersonsWebApi.Models.DTO
{
    /// <summary>Модель для запроса на создание или изменение записи о человеке</summary>
    public class PersonCreateAndUpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
    }
}
