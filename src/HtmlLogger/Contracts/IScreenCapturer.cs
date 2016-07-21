namespace HtmlLogger.Contracts
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public interface IScreenCapturer
    {
        Image CaptureScreen();

        void CaptureScreenToFile(string filename, ImageFormat format);

        Image CaptureWindow(IntPtr handle);

        void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format);

        IntPtr GetActiveWindowHandle();
    }
}