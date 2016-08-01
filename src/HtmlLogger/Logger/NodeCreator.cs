namespace HtmlLogger.Logger
{
    using HtmlAgilityPack;
    using HtmlLogger.Contracts;
    using HtmlLogger.Model;
    using HtmlLogger.Utils;
    using System.IO;

    internal class NodeCreator : INodeCreator
    {
        private readonly IMonkeyScreenCapturer _monkeyScreenCapturer;

        private const string HtmlRowTemplateFileName = "HtmlRowTemplate.txt";
        private static int _rowNumber = 1;

        public NodeCreator(IMonkeyScreenCapturer monkeyScreenCapturer)
        {
            Guard.Against.Null(nameof(monkeyScreenCapturer), monkeyScreenCapturer);

            this._monkeyScreenCapturer = monkeyScreenCapturer;
        }

        public HtmlNode CreateNode(string message, bool isScreenShotNeeded, LogCategory logCategory)
        {
            var template = File.ReadAllText(HtmlRowTemplateFileName);

            string screenShotImgValue = null;

            if (isScreenShotNeeded)
            {
                screenShotImgValue = this._monkeyScreenCapturer.CaptureScreenToFile();
            }

            var style = HtmlAttributeHelper.GetStyleByCategory(logCategory);

            var filledHtmlText = string.Format(template, _rowNumber++, style.FirstRowClass, message, screenShotImgValue, style.SpanText, style.SpanClass);

            return HtmlNode.CreateNode(filledHtmlText);
        }
    }
}