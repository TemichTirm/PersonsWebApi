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
    public class DatabaseHandler : IDatabaseHandler<Person>
    {
        private static readonly string _fileName = "initial_data.json";
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

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
