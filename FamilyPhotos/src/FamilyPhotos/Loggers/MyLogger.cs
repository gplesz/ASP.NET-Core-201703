using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Loggers
{
    public class MyLogger : ILogger
    {
        private string categoryName;
        private int intParam;
        private string stringParam;

        public MyLogger(string categoryName, string stringParam, int intParam)
        {
            this.categoryName = categoryName;
            this.stringParam = stringParam;
            this.intParam = intParam;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NoopDisposable.Instance; //Ha a scope-ot jegyezni szeretnénk
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true; //ha van szűrő ezzel lehet jelezni, hogy benne vagyunk-e a szűrésben vagy nem
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception); //A state a beginscope-ban jelzett állapot

            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }


        }
    }
}
