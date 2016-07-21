using HtmlLogger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        private static void CaptureScreen()
        {
            ScreenCapturer sc = new ScreenCapturer();

            // capture entire screen and save it
            sc.CaptureScreenToFile("temp2.png", ImageFormat.Png);
        }

        private static void CaptureActualWindow()
        {
            ScreenCapturer sc = new ScreenCapturer();

            // capture this window, and save it
            sc.CaptureWindowToFile(sc.GetActiveWindowHandle(), "temp3.png", ImageFormat.Png);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("R U Ready?");
            Console.ReadKey();

            CaptureActualWindow();
            Console.ReadKey();
        }
    }
}
