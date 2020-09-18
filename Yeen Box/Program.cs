using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yeen_Box_Lib;

namespace Yeen_Box
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            using (YannieYeen game = new YannieYeen(800, 600, "Yeen Box"))
            {
                game.Run(60.0);
            }
        }
    }
}
