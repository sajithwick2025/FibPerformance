using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace FibPerformance
{
    public class Program
    {      
     private static Dictionary<int, BigInteger> memo = new Dictionary<int, BigInteger>();
//With Data Dictionary 
    private static BigInteger Fib(int n)
    {
        if (n < 0)
            throw new ArgumentException("Input must be a non-negative integer");

        if (memo.TryGetValue(n, out var val))
            return val;

        if (n <= 1)
            val = n;
        else
            val = Fib(n - 2) + Fib(n - 1);

        memo[n] = val;
        return val;
    }

    // naive recursive without dictionary (very slow for large n)
    private static BigInteger Fib1(int n)
    {
        if (n < 0)
            throw new ArgumentException("Input must be a non-negative integer");

        if (n <= 1)
            return n;

        return Fib1(n - 1) + Fib1(n - 2);
    }

    // iterative without dictionary, uses BigInteger
    private static BigInteger Fib2(int n)
    {
        if (n < 0)
            throw new ArgumentException("Input must be a non-negative integer");

        if (n <= 1)
            return n;

        BigInteger a = 0;
        BigInteger b = 1;
        for (int i = 2; i <= n; i++)
        {
            BigInteger c = a + b;
            a = b;
            b = c;
        }
        return b;
    }
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            int[] tests = new[] { 10, 50, 100, 200, 300, 400, 500 };

            foreach (var n in tests)
            {
                // Measure recursive memoized Fib (cold)
                memo.Clear();
                sw.Restart();
                var fRec = Fib(n);
                sw.Stop();
                Console.WriteLine($"Fib({n}) [recursive+memo]: {fRec}  Elapsed: {sw.Elapsed.TotalMilliseconds} ms");

                // Measure naive recursive Fib1 only for small n (avoid extremely long runs)
                if (n <= 30)
                {
                    sw.Restart();
                    var fNaive = Fib1(n);
                    sw.Stop();
                    Console.WriteLine($"Fib1({n}) [recursive naive]: {fNaive}  Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
                }
                else
                {
                    Console.WriteLine($"Fib1({n}) [recursive naive]: skipped (would be too slow for n={n})");
                }

                // Measure iterative Fib2
                sw.Restart();
                var fIter = Fib2(n);
                sw.Stop();
                Console.WriteLine($"Fib2({n}) [iterative]:       {fIter}  Elapsed: {sw.Elapsed.TotalMilliseconds} ms");

                Console.WriteLine(new string('-', 50));
            }

            sw.Restart();
            Console.WriteLine("Hello, World!");
            sw.Stop();
            Console.WriteLine($"Elapsed for Hello write: {sw.Elapsed.TotalMilliseconds} ms");
        }
    }
}
