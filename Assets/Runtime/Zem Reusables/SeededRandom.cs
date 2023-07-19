using System;
using System.Collections;
using System.Collections.Generic;

namespace ZemReusables
{
    public class SeededRandom
    {
        public SeededRandom(string seed)
        {
            if (string.IsNullOrEmpty(seed))
            {
                seed = Guid.NewGuid().ToString();
            }
            Seed = seed;
            SeedInt = seed.GetHashCode();
            Random = new Random(SeedInt);
        }

        public string Seed { get; }
        public int SeedInt { get; }
        public Random Random { get; }

        public int Next()
        {
            return Random.Next();
        }

        public float NextFloat()
        {
            return (float)Random.NextDouble();
        }

        public bool NextBool()
        {
            return Range(0, 2) > 0;
        }

        public int Range(int minInclusive, int maxExclusive)
        {
            if (maxExclusive < minInclusive)
            {
                (minInclusive, maxExclusive) = (maxExclusive, minInclusive);
            }
            return Random.Next(minInclusive, maxExclusive);
        }
    }
}
