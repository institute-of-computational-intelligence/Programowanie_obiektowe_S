using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Utilities
    {
        public static void CheckNullOrWhitespace(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentException();
        }

        public static void CheckNull(object obj)
        {
            if (obj == null) throw new ArgumentNullException();
        }
    }
}
