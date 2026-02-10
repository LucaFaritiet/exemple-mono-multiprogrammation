using System;
using System.Collections.Generic;
using System.Text;

namespace MonoVSMultiProg.IViewModel
{
    internal interface IViewModel
    {
        static abstract void PrintMenu();
        static abstract int HandleInput(string input);
        static abstract void RunSelectedProgram(int program);
    }
}
