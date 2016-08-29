using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            const int N = 28;
            
            Stack<int> ring1 = new Stack<int>();

            Initialise(N, ring1);

            Stack<int> ring2 = new Stack<int>();
            Stack<int> ring3 = new Stack<int>();

            LoopMethod(N, ring1, ring2, ring3);

            Console.WriteLine("End");
            Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed.Seconds);
            double numberOfMoves = Math.Pow(2, N) - 1;
            double maxMoves = Math.Pow(2, 64) - 1;
            double esimatedSecods = (maxMoves / numberOfMoves) * stopWatch.Elapsed.Seconds;
            Console.WriteLine("Estimated years: {0}", TimeSpan.FromDays(esimatedSecods / (3600 * 24)).Days / 365 );
            Console.WriteLine("End");
            Console.ReadLine();
        }

        private static void LoopMethod(int n, Stack<int> ring1, Stack<int> ring2, Stack<int> ring3)
        {
            if (n % 2 == 1)
            {
                OddAlgorytm(n, ring1, ring2, ring3);
            }
            else
            {
                EvenAlgorytm(n, ring1, ring2, ring3);
            }
        }

        private static void Initialise(int n, Stack<int> ring1)
        {
            for (int i = n; i >= 1; i--)
            {
                ring1.Push(i);
            }
        }

        private static void OddAlgorytm(int n, Stack<int> ring1, Stack<int> ring2, Stack<int> ring3)
        {
            Console.WriteLine("OddAlgorytm");
            double numberOfMoves = Loop(n);

            Console.WriteLine(numberOfMoves);
        }

        private static double Loop(int n)
        {
            double numberOfMoves = Math.Pow(2, n) - 1;

            int counter = 1;
            for (double i = 1; i < numberOfMoves; i++)
            {
                

                if ((i % (numberOfMoves / 100)) < 1)
                {
                    Console.WriteLine("i={0}; Progress: {1}%", i, i / numberOfMoves * 100);
                }

                if (counter > 3)
                    counter = 1;

                switch (counter)
                {
                    case 1:
                        //1-3
                        break;
                    case 2:
                        {
                            //1-2
                        }
                        break;
                    case 3:
                        {
                            //2-3
                        }
                        break;
                }

                counter++;
            }
            return numberOfMoves;
        }

        private static void EvenAlgorytm(int n, Stack<int> ring1, Stack<int> ring2, Stack<int> ring3)
        {
            // 1-2, 1-3, 2-3
            Console.WriteLine("EvenAlgorytm");
            double numberOfMoves = Loop(n);

            Console.WriteLine(numberOfMoves);

        }
    }
}

