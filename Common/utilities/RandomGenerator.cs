using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utilities
{
    public static class RandomGenerator
    {
        static Random random = new Random();
        public static string GenerateString(int charCount)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, charCount)
              .Select(s => s[random.Next(s.Length)]).ToArray());

        }
    }
}
