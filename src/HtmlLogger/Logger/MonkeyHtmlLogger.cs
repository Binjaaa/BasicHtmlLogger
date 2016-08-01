namespace HtmlLogger.Logger
{
    using Contracts;
    using HtmlHelper;
    using Model;
    using Utils;

    /// <summary>
    ///
    /// </summary>
    public sealed class MonkeyHtmlLogger : MonkeyHtmlLoggerBase
    {
        #region Fields

        private readonly IHtmlHelper _htmlHelper;
        private readonly INodeCreator _nodeCreator;

        #endregion Fields

        #region Constructors

        public MonkeyHtmlLogger(string templateFolderPath, string destinationPath)
        {
            Guard.Against.NullOrEmpty(nameof(templateFolderPath), templateFolderPath);
            Guard.Against.NullOrEmpty(nameof(destinationPath), destinationPath);

            var ioHelper = new IoHelper();
            var fileGenerator = new FileGenerator(templateFolderPath, destinationPath, ioHelper);

            this._htmlHelper = new HtmlHelper(fileGenerator);
            this._monkeyScreenCapturer = new MonkeyScreenCapturer(new ScreenCapturer(), fileGenerator);
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