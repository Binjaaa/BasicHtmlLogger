namespace HtmlLogger.Logger
{
    using HtmlAgilityPack;
    using HtmlHelper;
    using Model;
    using System.IO;
    using Utils;

    /// <summary>
    ///
    /// </summary>
    public sealed class HtmlLogger : HtmlLoggerBase
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly string _tamplatePath;

        public HtmlLogger(string templatePath, IHtmlHelper htmlHelper = null)
        {
            if (htmlHelper == null)
            {
                htmlHelper = new HtmlHelper(new IoHelper(), templatePath);
            }

            Guard.Against.Null(nameof(templatePath), templatePath);

            this._htmlHelper = htmlHelper;
            this._tamplatePath = templatePath;
        }

        public override void LogError(string message, bool isScreenShotNeeded)
        {
            this.Log(message, isScreenShotNeeded, LogCategory.Error);
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
            //TODO: Finalize, it is just for testing at this moment!
            var str = File.ReadAllText("HtmlRowTemplate.txt");

            var filledHtmlText = string.Format(str, 4, category, message, "2016 - 07 - 22_10 - 26 - 19.png");
            var newNode = HtmlNode.CreateNode(filledHtmlText);

            _htmlHelper.AddMessageRow(newNode);
        }
    }
}