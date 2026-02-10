using MonoVSMultiProg.MonoNMultiModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MonoVSMultiProg.ViewModel
{
    internal class ViewModel : IViewModel.IViewModel
    {
        // Empty constructor 'cause we can't have static ... so sad...
        public ViewModel()
        {
        }
        public static void PrintMenu()
        {
            Console.WriteLine("Welcome to MonoVSMultiProg!");
            Console.WriteLine("Please select a program to run:");
            Console.WriteLine("1. Monoprog");
            Console.WriteLine("2. Multiprog");
            Console.WriteLine("3. Exit");
            Console.Write("Type here: ");
        }

        public static int HandleInput(string input)
        {
            switch (input)
            {
                case "1":
                    // Run Monoprog
                    Console.Clear();
                    Console.WriteLine("Running Monoprog...");
                    RunSelectedProgram(int.Parse(input));
                    return 1;
                case "2":
                    // Run Multiprog
                    Console.Clear();
                    Console.WriteLine("Running Multiprog...");
                    RunSelectedProgram(int.Parse(input));
                    return 2;
                case "3":
                    // Exit
                    Console.Clear();
                    Console.Write("Exiting");
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == 3) Console.WriteLine(".");
                        else Console.Write(".");
                        Thread.Sleep(1000 + i * 100);
                    }
                    return 3;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please try again.");
                    PrintMenu();
                    return 0;
            }
        }

        public static void RunSelectedProgram(int program)
        {
            switch (program)
            {
                case 1:
                    // Run Monoprog
                    Console.Clear();
                    Console.WriteLine("Running Monoprog...");
                    Monoprog.Run();
                    break;
                case 2:
                    // Run Multiprog
                    Console.Clear();
                    Console.WriteLine("Running Multiprog...");
                    Multiprog.Run();
                    break;
                default:
                    Console.WriteLine("Invalid program selected.");
                    break;
            }
        }
    }
}
