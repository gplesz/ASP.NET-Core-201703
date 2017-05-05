using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Loggers
{
    public class NoopDisposable : IDisposable
    {
        public static NoopDisposable Instance = new NoopDisposable();
        public void Dispose()
        { }
    }
}
