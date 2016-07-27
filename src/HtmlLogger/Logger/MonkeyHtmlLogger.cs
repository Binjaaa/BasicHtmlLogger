namespace HtmlLogger.Logger
{
    using Contracts;
    using HtmlAgilityPack;
    using HtmlHelper;
    using Model;
    using System;
    using System.Collections.Generic;
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
        private readonly IHtmlHelper _htmlHelper;
        private readonly IIoHelper _ioHelper;
        private readonly IMonkeyScreenCapturer _monkeyScreenCapturer;
        private readonly string _templateFolderPath;
        private int _rowNumber = 1;

        #endregion Fields

        #region Constructors

        public MonkeyHtmlLogger(string templateFolderPath, string destinationPath, IHtmlHelper htmlHelper = null, IMonkeyScreenCapturer monkeyScreenCapturer = null, IIoHelper ioHelper = null)
        {
            Guard.Against.NullOrEmpty(nameof(templateFolderPath), templateFolderPath);
            Guard.Against.NullOrEmpty(nameof(destinationPath), destinationPath);

            htmlHelper = htmlHelper ?? new HtmlHelper(new IoHelper(), templateFolderPath, destinationPath);
            monkeyScreenCapturer = monkeyScreenCapturer ?? new MonkeyScreenCapturer();
            ioHelper = ioHelper ?? new IoHelper();

            this._templateFolderPath = templateFolderPath;
            this._destinationPath = destinationPath;
            this._htmlHelper = htmlHelper;
            this._monkeyScreenCapturer = monkeyScreenCapturer;
            this._ioHelper = ioHelper;

            if (!this._ioHelper.DirectoryExists(templateFolderPath))
            {
                throw new ArgumentException($"The given {nameof(templateFolderPath)} is not existing: {templateFolderPath}");
            }
            this._ioHelper.CreateDirectoryIfNotExists(this._destinationPath);
        }

        #endregion Constructors

        #region Methods

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