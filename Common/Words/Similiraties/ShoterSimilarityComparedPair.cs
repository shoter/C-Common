using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Words.Similiraties
{
    public class ShoterSimilarityComparedPair
    {
        public string Pair { get; set; }
        public double Score { get; set; }

        public ShoterSimilarityComparedPair(string pair, double score)
        {
            Pair = pair;
            Score = score;
        }

        public override string ToString()
        {
            return $"{Pair} - {Score}";
        }
    }
}
