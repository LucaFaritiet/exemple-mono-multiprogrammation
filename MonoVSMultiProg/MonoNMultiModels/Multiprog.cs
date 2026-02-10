using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MonoVSMultiProg.MonoNMultiModels
{
    internal class Multiprog
    {
        public static void Run()
        {
            static async Task MultiMain()
            {
                var sw = Stopwatch.StartNew();
                Console.WriteLine("Multiprogrammation (simulation applicative) : chevauchement E/S et CPU.\n");

                // 1) Tâche d'E/S asynchrone (libère le thread pendant l'attente)
                var ioTask = SimulateIOAsync(2000); // ~2 s
                int ioTaskId = ioTask.Id;
                // 2) Tâche CPU exécutée en parallèle
                var cpuTask = Task.Run(() => DoCpuBoundWork(10_000_000));
                int cpuTaskId = cpuTask.Id;

                Console.WriteLine($"Started (ID {ioTaskId}) I/O and CPU (ID {cpuTaskId}) Tasks.");
                await Task.WhenAll(ioTask, cpuTask);

                sw.Stop();
                Console.WriteLine($"\nLasted (chevauchement) ≈ {sw.ElapsedMilliseconds} ms");
                Console.WriteLine("Observation : la durée est proche du max(E/S, CPU), pas de leur somme.");
            }
            static async Task SimulateIOAsync(int ms)
            {
                Console.WriteLine("I/O : Begin (asynchrone)...");
                await Task.Delay(ms); // pendant cette attente, le CPU exécute la tâche CPU
                Console.WriteLine("I/O : End.");
            }

            static void DoCpuBoundWork(int iterations)
            {
                Console.WriteLine("CPU : Began maths...");
                double s = 0;
                for (int i = 0; i < iterations; i++)
                    s += Math.Sqrt(i);
                Console.WriteLine($"CPU : Ended. Result = {s:N2}");
            }
            var exe = MultiMain();
            exe.Wait();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
