using System.Collections.Generic;
using System.Numerics;

namespace CoperAlgoLib
{
    public static class Maths
    {
        public static IEnumerable<int> GetAllDivisors(int x)
        {
            for (int factor = 1; factor * factor <= x; ++factor)
                if (x % factor == 0)
                {
                    yield return factor;
                    if (factor * factor != x)
                        yield return x / factor;
                }
        }

        /// <remarks>
        /// With <see cref="BigInteger"/>, use directly <code>BigInteger.GreatestCommonDivisor()</code>
        /// </remarks>
        public static T GCD<T>(T a, T b) where T : IBinaryInteger<T>
        {
            while (!T.IsZero(b))
                (a, b) = (b, a % b);
            return a;
        }

        public static T LCM<T>(T a, T b) where T : IBinaryInteger<T>
        {
            T gcd = GCD(a, b);
            return T.IsZero(gcd) ? T.Zero : a / gcd * b;
        }
    }
}
