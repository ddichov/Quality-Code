using System;
using System.Linq;

namespace BalloonsPop
{
    internal static class RandomGenerator
    {
        private static readonly Random randomGenerator;

        static RandomGenerator()
        {
            randomGenerator = new Random();
        }

        internal static int GetNext(int minValue, int maxValue)
        {
            return randomGenerator.Next(minValue, maxValue + 1);
        }
    }
}
