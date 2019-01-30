using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Words.Similiraties
{
    public class LevenshteinSimilarity : ISimilarityAlgorithm
    {
        public double CalculateSimilarity(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2))
                return 0.0;

            s1 = s1.ToLower();
            s2 = s2.ToLower();
            double length = Math.Pow((s1.Count() + s2.Count()) / 2, 1.1);
            double distance = LavDistance(s1, s2);
            return (length - distance) / length;
        }

        private static double LavDistance(string s1, string s2)
        {
            if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2)) return 0;

            int lengthA = s1.Length;
            int lengthB = s2.Length;
            var distances = new int[lengthA + 1, lengthB + 1];
            for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
            for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

            for (int i = 1; i <= lengthA; i++)
                for (int j = 1; j <= lengthB; j++)
                {
                    int cost = s2[j - 1] == s1[i - 1] ? 0 : 1;
                    distances[i, j] = Math.Min
                        (
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + cost
                        );
                }
            Console.WriteLine($"Distance = {distances[lengthA, lengthB]}");
            return distances[lengthA, lengthB];
        }
    }
}
