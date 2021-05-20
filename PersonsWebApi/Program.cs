using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace PersonsWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            //var repo = new PersonsPepository(new DatabaseHandler());
            //var person = new Person { Id = 100, FirstName = "AAAAAAA", LastName = "BBBBB", Email = "ccc@dddddd.ru", Company = "FFFFFF", Age = 40 };
            ////repo.Delete(10);
            //var result = repo.GetList(5, -4);
            //Console.WriteLine();
            try
            {
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            // ����� ���� ���������� � ������ ������ ����������
            catch (Exception exception)
            {
                //NLog: ������������� ����� ����������
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // ��������� ������ 
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls("http://localhost:5000");
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders(); // �������� ����������� �����������
                    logging.SetMinimumLevel(LogLevel.Trace); // ������������� ����������� ������� �����������
                }).UseNLog(); // ��������� ���������� nlog;
    }
}
