using NLog;
using PersonsWebApi.Data.Interfaces;
using PersonsWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonsWebApi.Data.Implementation
{
    /// <summary>Обработчик базы данных, хранящей записи типа Person</summary>
    public class DatabaseHandler : IDatabaseHandler<Person>
    {
        private static readonly string _fileName = "initial_data.json";
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>Возвращает все данные типа Person из базы данных</summary>
        /// <returns>Коллекция записей Person</returns>
        public async Task<IEnumerable<Person>> GetData()
        {
            try
            {
                using (var streamReader = new StreamReader(_fileName))
                {
                    var serializedJson = await streamReader.ReadToEndAsync();
                    var result = JsonSerializer.Deserialize<IEnumerable<Person>>(serializedJson,
                                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                };
            }
            catch (UnauthorizedAccessException e)
            {
                _logger.Error($"Can't get access to file {_fileName}. {e.InnerException}");
            }
            catch (IOException e)
            {
                _logger.Error($"Can't write data into file. {e.InnerException}");
            }
            catch (Exception e)
            {
                _logger.Error($"Some problem occured. {e.InnerException}");
            }
            return null;
        }

        /// <summary>Сохраняет данные типа Person в базу данных</summary>
        /// <param name="persons">Коллекция записей типа Person</param>
        /// <param name="append">Флаг дозаписи. True - если база данных существует, данные будут добавлены в конец</param>
        public async Task SaveDataCollection(IEnumerable<Person> persons, bool append = true)
        {
            try
            {
                using (var streamWriter = new StreamWriter(_fileName, append))
                {
                    string serializedJson = JsonSerializer.Serialize(persons, 
                                        new JsonSerializerOptions { WriteIndented = true });                    
                    await streamWriter.WriteAsync(serializedJson);                    
                };
            }
            catch (UnauthorizedAccessException e)
            {
                _logger.Error($"Can't get access to file {_fileName}. {e.InnerException}");
            }
            catch (IOException e)
            {
                _logger.Error($"Can't write data into file. {e.InnerException}");
            }
            catch (Exception e)
            {
                _logger.Error($"Some problem occured. {e.InnerException}");
            }
        }

        /// <summary>Сохраняет экземпляр типа Person в базу данных</summary>
        /// <param name="person">Объект типа Person</param>
        public async Task SaveDataItem(Person person)
        {
            try
            {
                using (var streamWriter = new StreamWriter(_fileName, true))
                {
                    string serializedJson = JsonSerializer.Serialize(person,
                                        new JsonSerializerOptions { WriteIndented = true });
                    await streamWriter.WriteAsync(serializedJson);
                };
            }
            catch (UnauthorizedAccessException e)
            {
                _logger.Error($"Can't get access to file {_fileName}. {e.InnerException}");
            }
            catch (IOException e)
            {
                _logger.Error($"Can't write data into file. {e.InnerException}");
            }
            catch (Exception e)
            {
                _logger.Error($"Some problem occured. {e.InnerException}");
            }
        }

    }
}
