

using MonoVSMultiProg.ViewModel;

static class Program
{
    static void Main()
    { 
        while (true)
        {
            ViewModel.PrintMenu();
            string? input = Console.ReadLine();
            if (input is null)
            {
                // Treat EOF (null input) as exit.
                break;
            }
            int result = ViewModel.HandleInput(input);

            while (result == 0)
            {
                input = Console.ReadLine();
                if (input is null)
                {
                    // Treat EOF (null input) as exit.
                    result = 3;
                    break;
                }
                result = ViewModel.HandleInput(input);
                if (result == 3) break;
            }
            if (result == 3) break;
        }

    }
}