using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace SistemaListaAtividade.Extensions
{
    public class LogExtension
    {
        private static readonly string LogDirectory = "C://ProjParticular//SistemaListaAtividade//SistemaListaAtividade//Logs";

        static LogExtension()
        {
            InitializeLogger();
        }

        public static void InitializeLogger()
        {
            try
            {
                Directory.CreateDirectory(LogDirectory);
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console(LogEventLevel.Debug)
                    .WriteTo.File(Path.Combine(LogDirectory, "log-.txt"), rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, fileSizeLimitBytes: 1000000)
                    .CreateLogger();

                // Excluir arquivo de log do dia anterior
                DeletePreviousLogFile();
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção, registre-a no console
                Console.WriteLine($"Erro ao inicializar o logger: {ex.Message}");
            }
        }

        private static void DeletePreviousLogFile()
        {
            var yesterdayDate = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");
            var logFilePath = Path.Combine(LogDirectory, $"log-{yesterdayDate}.txt");
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }
        }

        public static ILogger GetLogger()
        {
            return Log.Logger;
        }
    }
}