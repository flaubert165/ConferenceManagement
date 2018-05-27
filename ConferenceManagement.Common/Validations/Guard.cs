using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceManagement.Common.Resources;

namespace ConferenceManagement.Common.Validations
{
    public static class Guard
    {

        public static void ForNullOrEmpty(string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(Messages.FileNotFound);
        }

        public static void IEnumerableIsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            if (list == null || !list.Any())
                throw new Exception(Messages.FileContentNullOrEmpty);
        }

    }
}