using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Loggers
{
    public class MyLoggerProvider : ILoggerProvider
    {
        private int intParam;
        private string stringParam;

        public MyLoggerProvider(string stringParam, int intParam)
        {
            this.stringParam = stringParam;
            this.intParam = intParam;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger(categoryName, stringParam, intParam);
        }

        public void Dispose()
        {
            
        }
    }
}
