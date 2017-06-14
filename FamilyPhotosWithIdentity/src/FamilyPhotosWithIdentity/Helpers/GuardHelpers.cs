using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotosWithIdentity.Helpers
{
    public static class GuardHelpers
    {
        public static T ThrowIfNull<T>(this T o)
            where T : class
        {
            if (null == o) { throw new ArgumentNullException(typeof(T).Name); }
            return o;
        }
    }
}
