using OpenTK.Windowing.Desktop;
using System;

namespace YeenBoxLib
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MainWindow game = new MainWindow())
            {
                game.Run();
            }
        }
    }
}
