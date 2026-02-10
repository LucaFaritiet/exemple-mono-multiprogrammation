
using MonoVSMultiProg.IViewModel;
using MonoVSMultiProg.ViewModel;

static class Program
{
    static void Main()
    {
        Run<ViewModel>();
    }

    // This method uses generic constraints to work with IViewModel interface
    // following MVVM principles by depending on the abstraction (IViewModel) 
    // rather than the concrete implementation (ViewModel)
    static void Run<TViewModel>() where TViewModel : IViewModel
    { 
        while (true)
        {
            TViewModel.PrintMenu();
            string? input = Console.ReadLine();
            if (input is null)
            {
                // Treat EOF (null input) as exit.
                break;
            }
            int result = TViewModel.HandleInput(input);

            while (result == 0)
            {
                input = Console.ReadLine();
                if (input is null)
                {
                    // Treat EOF (null input) as exit.
                    result = 3;
                    break;
                }
                result = TViewModel.HandleInput(input);
                if (result == 3) break;
            }
            if (result == 3) break;
        }

    }
}