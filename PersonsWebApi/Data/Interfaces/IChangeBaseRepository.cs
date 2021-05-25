
namespace PersonsWebApi.Data.Interfaces
{
    /// <summary>Интерфейс содержащий методы для изменения записей в базе данных</summary>
    /// <typeparam name="T">Тип записей в базе данных</typeparam>
    public interface IChangeBaseRepository<T>
    {
        /// <summary>Добавляет запись заданного типа в базу данных</summary>
        /// <param name="item">Объект заданного типа</param>
        public void Create(T item);

        /// <summary>Изменяет существующую запись заданного типа в базе данных</summary>
        /// <param name="item">Объект заданного типа</param>
        public bool Update(T item);

        /// <summary>Удаляет запись заданного типа из базы данных</summary>
        /// <param name="id">Id записи, которую необходимо удалить</param>
        public bool Delete(int id);
    }
}
