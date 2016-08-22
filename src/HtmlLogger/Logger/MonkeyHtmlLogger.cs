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

            var monkeyScreenCapturer = new MonkeyScreenCapturer(new ScreenCapturer(), fileGenerator);
            this._nodeCreator = new NodeCreator(monkeyScreenCapturer);
        }

        #endregion Constructors

        #region Methods

        public override void AppendToRunDetails(string name, string value)
        {
            var detailsNode = this._nodeCreator.CreateDetailsNode(name, value);

            this._htmlHelper.AppendToRunDetailsTable(detailsNode);
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
            var newNode = this._nodeCreator.CreateNode(message, isScreenShotNeeded, category);

            this._htmlHelper.AddMessageRow(newNode);
        }

        #endregion Methods
    }
}