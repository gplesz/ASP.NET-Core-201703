using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Loggers
{
    public static class MyLoggerExtensions
    {
        public static ILoggerFactory AddMyLog(this ILoggerFactory factory, string stringParam, int intParam)
        {
            factory.AddProvider(new MyLoggerProvider(stringParam, intParam));
            return factory;
        }
    }
}
