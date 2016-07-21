
namespace HtmlLogger.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IScreenCapturer
    {
        Image CaptureScreen();
        void CaptureScreenToFile(string filename, ImageFormat format);

        Image CaptureWindow(IntPtr handle);
        void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format);

        IntPtr GetActiveWindowHandle();
    }
}
