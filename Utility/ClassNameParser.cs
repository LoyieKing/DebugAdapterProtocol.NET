using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DebugAdapterProtocol.Utility
{
    public static class ClassNameParser
    {
        private static char[] charPool = new char[128];

        public static string Parse(string className, string suffix)
        {
            if (className.Length <= suffix.Length)
                return null;

            for (int i = 0, j = className.Length - suffix.Length; i < suffix.Length; i++, j++)
            {
                if (className[j] != suffix[i])
                    return null;
            }

            var span = charPool.AsSpan(0, className.Length - suffix.Length);
            for (int i = 0; i < span.Length; i++)
            {
                span[i] = className[i];
            }

            Debug.Assert(span[0] >= 'A' && span[0] <= 'Z');

            span[0] += (char)0x20; //'a'-'A' = 0x61-0x41 = 0x20

            return new string(span);
        }
    }
}
