using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace GThorRepositorioEntityFramework.Rastreamento
{
    public class EfLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            File.AppendAllText(@".\EF.LOG", formatter(state, exception));
            Console.WriteLine(formatter(state, exception));
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}