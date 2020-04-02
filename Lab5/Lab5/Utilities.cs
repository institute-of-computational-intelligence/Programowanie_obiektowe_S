using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Utilities
    {
        /// <summary>Checks given string for null reference or if the string is only whitespace.</summary>  
        public static void CheckNullOrWhitespace(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentException();
        }

        /// <summary>Checks given object for null reference.</summary> 
        public static void CheckNull(object obj)
        {
            if (obj == null) throw new ArgumentNullException();
        }
    }
}
