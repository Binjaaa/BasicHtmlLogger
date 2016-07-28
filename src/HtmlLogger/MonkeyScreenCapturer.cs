namespace HtmlLogger
{
    using HtmlLogger.Contracts;
    using System;
    using System.Drawing.Imaging;

    using HtmlLogger.Utils;

    public class MonkeyScreenCapturer : IMonkeyScreenCapturer
    {
        private readonly IScreenCapturer _screenCapturer;
        private readonly IFileNameGenerator _fileNameGenerator;

        public MonkeyScreenCapturer(IScreenCapturer screenCapturer, IFileNameGenerator fileNameGenerator)
        {
            Guard.Against.Null(nameof(screenCapturer), screenCapturer);
            Guard.Against.Null(nameof(fileNameGenerator), fileNameGenerator);

            this._screenCapturer = screenCapturer;
            this._fileNameGenerator = fileNameGenerator;
        }

        public string CaptureScreenToFile()
        {
            var screenShotFilePath = $"screenshot/{this._fileNameGenerator.GetScreenShotName()}";

            this._screenCapturer.CaptureScreenToFile($"Template/{screenShotFilePath}", ImageFormat.Png);

            return screenShotFilePath;
        }
    }
}