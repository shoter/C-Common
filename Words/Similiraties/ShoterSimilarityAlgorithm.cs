using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Words.Similiraties
{
    public class ShoterSimilarityAlgorithm : ISimilarityAlgorithm
    {
        public double CalculateSimilarity(string original, string compared)
        {
            var orgSet = createPairsFromString(original.Replace(" ", ""));
            var compSet = createPairsFromString(compared.Replace(" ", ""));

            var similarPairs = createSimiliarPairs(orgSet, compSet);


            double simScore = 0.0f;

            foreach (var simPair in similarPairs)
            {
                foreach(var orgPair in orgSet)
                {
                    if (orgPair == simPair.Pair)
                    {
                        simScore += simPair.Score;
                        break;
                    }
                } 
            }

            return (2 * simScore) / (orgSet.Count + compSet.Count);
        }

        private static List<string> createPairsFromString(string str)
        {
            List<string> ret = new List<string>();
            for (int i = 1; i < str.Length; ++i)
            {
                var sub = str.Substring(i - 1, 2);

                ret.Add(sub.ToLower());
            }

            return ret;
        }

        private static IEnumerable<ShoterSimilarityComparedPair> createSimiliarPairs(List<string> orgSet, List<string> compSet)
        {
            for (int compPos = 0; compPos < compSet.Count; ++compPos)
            {
                var compPair = compSet[compPos];
                int smallestDistance = int.MaxValue;
                for (int orgPos = 0; orgPos < orgSet.Count; ++orgPos)
                {
                    var orgPair = orgSet[orgPos];

                    if (orgPair == compPair)
                    {
                        int distance = Math.Abs(compPos - orgPos);
                        if (distance < smallestDistance)
                            smallestDistance = distance;

                    }
                }

                if (smallestDistance < int.MaxValue)
                {
                    double similarityScore = Math.Pow(1f - smallestDistance / 20f, 2);
                    yield return new ShoterSimilarityComparedPair(compPair, similarityScore);
                }
            }
        }

    }
}
