namespace HtmlLogger.Contracts
{
    using System.Drawing.Imaging;

    public interface IMonkeyScreenCapturer
    {
        string CaptureScreenToFile();
    }
}