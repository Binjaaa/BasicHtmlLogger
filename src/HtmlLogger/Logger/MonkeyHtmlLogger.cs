namespace HtmlLogger.Logger
{
    using Contracts;
    using HtmlAgilityPack;
    using HtmlHelper;
    using Model;
    using System;
    using System.IO;
    using Utils;

    /// <summary>
    ///
    /// </summary>
    public sealed class MonkeyHtmlLogger : MonkeyHtmlLoggerBase
    {
        #region Fields

        private const string HtmlRowTemplateFileName = "HtmlRowTemplate.txt";

        private readonly string _destinationPath;
        private readonly string _templateFolderPath;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IIoHelper _ioHelper;
        private readonly IMonkeyScreenCapturer _monkeyScreenCapturer;
        private readonly IFileNameGenerator _fileNameGenerator;
        private int _rowNumber = 1;

        #endregion Fields

        #region Constructors

        public MonkeyHtmlLogger(string templateFolderPath, string destinationPath)
        {
            Guard.Against.NullOrEmpty(nameof(templateFolderPath), templateFolderPath);
            Guard.Against.NullOrEmpty(nameof(destinationPath), destinationPath);

            this._templateFolderPath = templateFolderPath;
            this._destinationPath = destinationPath;

            this._ioHelper = new IoHelper();
            this._fileNameGenerator = new FileNameGenerator(destinationPath);
            //this._fileNameGenerator.EnsureFolders();

            this._htmlHelper = new HtmlHelper(new IoHelper(), _fileNameGenerator, templateFolderPath, destinationPath);
            this._monkeyScreenCapturer = new MonkeyScreenCapturer(new ScreenCapturer(), new FileNameGenerator(destinationPath));

            this.InitFolder();
        }

        #endregion Constructors

        #region Methods

        private LogDirectories InitFolder()
        {
            //Ensure "Destination" folder is exists
           var destinationPath = this._ioHelper.CreateDirectoryIfNotExists(this._destinationPath);

            //Create Current log folder
           var  this._ioHelper.CreateDirectoryIfNotExists(Path.Combine(this._destinationPath,_fileNameGenerato);

            //Create screenshots folder in log folder
        }

        public override void LogError(string message, bool isScreenShotNeeded)
        {
            this.Log(message, isScreenShotNeeded, LogCategory.Danger);
        }

        public override void LogInfo(string message, bool isScreenShotNeeded)
        {
            this.Log(message, isScreenShotNeeded, LogCategory.Info);
        }

        public override void LogWarning(string message, bool isScreenShotNeeded)
        {
            this.Log(message, isScreenShotNeeded, LogCategory.Warning);
        }

        protected override void Log(string message, bool isScreenShotNeeded, LogCategory category)
        {
            var str = File.ReadAllText(HtmlRowTemplateFileName);
            string screenShotPath = null;

            if (isScreenShotNeeded)
            {
                screenShotPath = this._monkeyScreenCapturer.CaptureScreenToFile();
            }

            var style = HtmlAttributeHelper.GetStyleByCategory(category);

            var filledHtmlText = string.Format(str, this._rowNumber++, style.FirstRowClass, message, screenShotPath, style.SpanText, style.SpanClass);
            var newNode = HtmlNode.CreateNode(filledHtmlText);

            this._htmlHelper.AddMessageRow(newNode);
        }

        #endregion Methods
    }
}