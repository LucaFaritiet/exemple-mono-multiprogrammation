using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace MonoVSMultiProg.MonoNMultiModels
{
    internal static class Monoprog
    {
        public static void Run() {
            
            static void DoIOBoundWorkSync(int ms)
            {
                Console.WriteLine("I/O : shhhhh.. thread is sleeping !");
                Thread.Sleep(ms);
                Console.WriteLine("I/O : Thread just woke up.");
            }

            static void DoCpuBoundWork(int iterations)
            {
                Console.WriteLine("CPU : doing some maths...");
                double s = 0;
                for (int i = 0; i < iterations; i++)
                    s += Math.Sqrt(i);
                Console.WriteLine($"CPU : Ended. Results = {s:N2}");
            }

            var sw = Stopwatch.StartNew();
            Console.WriteLine("Monoprogrammation : sequential execution only.\n");

            DoIOBoundWorkSync(2000);

            DoCpuBoundWork(1_000_000);

            sw.Stop();
            Console.WriteLine($"\nLasted ≈ {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
