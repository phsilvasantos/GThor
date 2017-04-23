using Microsoft.Extensions.Logging;

namespace GThorRepositorioEntityFramework.Rastreamento
{
    public class EfLoggerFactory : ILoggerFactory
    {
        public void Dispose()
        {
            
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new EfLogger();
        }

        public void AddProvider(ILoggerProvider provider)
        {
            
        }
    }
}