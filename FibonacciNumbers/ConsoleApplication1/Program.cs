using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //--------------- iterative version ---------------------    
        static int FibonacciIterative(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            int prevPrev = 0;
            int prev = 1;
            int result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = prev + prevPrev;
                prevPrev = prev;
                prev = result;
            }
            return result;
        }

        //--------------- naive recursive version --------------------- 
        static int FibonacciRecursive(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        //--------------- optimized recursive version ---------------------
        static Dictionary<int, int> resultHistory = new Dictionary<int, int>();

        // Recursion with memorization        
        static int FibonacciRecursiveOpt(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (resultHistory.ContainsKey(n))
                return resultHistory[n];

            int result = FibonacciRecursiveOpt(n - 1) + FibonacciRecursiveOpt(n - 2);
            resultHistory[n] = result;

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(FibonacciIterative(10));
            Console.WriteLine(FibonacciRecursive(10));
            Console.WriteLine(FibonacciRecursiveOpt(10));

#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }
    }

    
}

