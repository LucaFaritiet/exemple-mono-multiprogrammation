

using MonoVSMultiProg.ViewModel;

static class Program
{
    static void Main()
    { 
        while (true)
        {
            ViewModel.PrintMenu();
            string input = Console.ReadLine();
            int result = ViewModel.HandleInput(input);

            while (result == 0)
            {
                input = Console.ReadLine();
                result = ViewModel.HandleInput(input);
                if (result == 3) break;
            }
            if (result == 3) break;
        }

    }
}