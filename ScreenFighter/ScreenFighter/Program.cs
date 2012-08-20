using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenFighter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ScreenFighter screenFighter = new ScreenFighter();
            screenFighter.Initialize();

            Application.Run();

            screenFighter.Dispose();
        }
    }
}
