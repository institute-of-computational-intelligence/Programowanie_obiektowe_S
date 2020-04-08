using System;
using System.Collections.Generic;

namespace Lab6
{
    public class ParamCheck
    {
        /// <summary>Checks given object for null reference.</summary> 
        public static void IsNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>Checks given string for null reference or if the string is only whitespace.</summary>  
        public static void IsNullOrWhitespace(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException();
            }
        }

        /// <summary>Checks if given collection is null or empty.</summary>  
        public static void IsNullOrEmpty<T>(ICollection<T> collection)
        {
            if(collection == null)
            {
                throw new ArgumentNullException();
            }

            if(collection.Count == 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
