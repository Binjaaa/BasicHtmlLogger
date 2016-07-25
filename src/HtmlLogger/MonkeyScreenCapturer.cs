namespace HtmlLogger
{
    using HtmlLogger.Contracts;
    using System;
    using System.Drawing.Imaging;

    public class MonkeyScreenCapturer : IMonkeyScreenCapturer
    {
        private readonly IScreenCapturer _screenCapturer;

        public MonkeyScreenCapturer(IScreenCapturer screenCapturer = null)
        {
            screenCapturer = screenCapturer ?? new ScreenCapturer();

            this._screenCapturer = screenCapturer;
        }

        public string CaptureScreenToFile()
        {
            var screenShotFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            var screenShotFileNameWithExtension = $"{screenShotFileName}.png";

            var screenShotFilePath = $"screenshot/{screenShotFileNameWithExtension}";

            this._screenCapturer.CaptureScreenToFile($"Template/{screenShotFilePath}", ImageFormat.Png);

            return screenShotFilePath;
        }
    }
}