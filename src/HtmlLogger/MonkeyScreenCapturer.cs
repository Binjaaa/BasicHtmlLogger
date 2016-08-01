namespace HtmlLogger
{
    using HtmlLogger.Contracts;
    using HtmlLogger.Utils;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    public class MonkeyScreenCapturer : IMonkeyScreenCapturer
    {
        #region Fields

        private readonly IFileGenerator _fileGenerator;
        private readonly IScreenCapturer _screenCapturer;

        #endregion Fields

        #region Constructors

        public MonkeyScreenCapturer(IScreenCapturer screenCapturer, IFileGenerator fileNameGenerator)
        {
            Guard.Against.Null(nameof(screenCapturer), screenCapturer);
            Guard.Against.Null(nameof(fileNameGenerator), fileNameGenerator);

            this._screenCapturer = screenCapturer;
            this._fileGenerator = fileNameGenerator;
        }

        #endregion Constructors

        #region Methods

        public string CaptureScreenToFile()
        {
            var screenShotFullPath = Path.Combine(
                this._fileGenerator.GetScreenShotFullPath(),
                this._fileGenerator.GetScreenShotName());

            this._screenCapturer.CaptureScreenToFile(screenShotFullPath, ImageFormat.Png);

            return Path.Combine(new DirectoryInfo(screenShotFullPath).Parent?.Name, Path.GetFileName(screenShotFullPath));
        }

        #endregion Methods
    }
}