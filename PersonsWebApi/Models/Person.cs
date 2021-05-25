
namespace PersonsWebApi.Models
{
    /// <summary>Модель записи о человеке в базе данных</summary>
    public class Person
    {
        public Person()
        {

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
    }
}
