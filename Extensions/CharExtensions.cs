using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class CharExtensions
    {
        /// <summary>
        /// Change character to lowercase if able.
        /// </summary>
        public static char ToLower(this char character)
        {
            return char.ToLower(character);
        }
        /// <summary>
        /// Change character to uppercase if able.
        /// </summary>
        public static char ToUpper(this char character)
        {
            return char.ToUpper(character);
        }

        /// <summary>
        /// returns true if character is uppercase
        /// </summary>
        public static bool IsUpper(this char character)
        {
            return char.IsUpper(character);
        }

        /// <summary>
        /// returns true if character is lowercase
        /// </summary>
        public static bool IsLower(this char character)
        {
            return char.IsLower(character);
        }


    }
}
