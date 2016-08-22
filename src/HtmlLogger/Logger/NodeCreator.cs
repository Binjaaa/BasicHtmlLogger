namespace HtmlLogger.Logger
{
    using HtmlAgilityPack;
    using HtmlLogger.Contracts;
    using HtmlLogger.Model;
    using HtmlLogger.Utils;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal class NodeCreator : INodeCreator
    {
        private const string HtmlRowTemplateFileName = "HtmlRowTemplate.txt";
        private const string RunDetailsTemplateFileName = "RunDetailsTemplate.txt";
        private static int _rowNumber = 1;

        private readonly IMonkeyScreenCapturer _monkeyScreenCapturer;

        public NodeCreator(IMonkeyScreenCapturer monkeyScreenCapturer)
        {
            Guard.Against.Null(nameof(monkeyScreenCapturer), monkeyScreenCapturer);

            this._monkeyScreenCapturer = monkeyScreenCapturer;
        }

        public HtmlNode CreateDetailsNode(string name, string value)
        {
            var runDetailsTemplate = this.GetTemplateByName(RunDetailsTemplateFileName);

            var filledRunDetailsHtmlTemplate = string.Format(runDetailsTemplate, name, value);

            return HtmlNode.CreateNode(filledRunDetailsHtmlTemplate);
        }

        public HtmlNode CreateNode(string message, bool isScreenShotNeeded, LogCategory logCategory)
        {
            var template = this.GetTemplateByName(HtmlRowTemplateFileName);

            string imgHtmlTag = string.Empty;

            if (isScreenShotNeeded)
            {
                var screenShotImgValue = this._monkeyScreenCapturer.CaptureScreenToFile();

                imgHtmlTag = $"<a href = \"{screenShotImgValue}\" class = \"thumbnail\"><img src = \"{screenShotImgValue}\"></a>";
            }

            var style = HtmlAttributeHelper.GetStyleByCategory(logCategory);

            var filledHtmlText = string.Format(template, _rowNumber++, style.FirstRowClass, message, imgHtmlTag, style.SpanText, style.SpanClass);

            return HtmlNode.CreateNode(filledHtmlText);
        }

        private string GetTemplateByName(string fileName)
        {
            string result;

            var assembly = Assembly.GetExecutingAssembly();

            var manifestResourceName = assembly.GetManifestResourceNames()
                                               .FirstOrDefault(item => item.EndsWith(fileName));

            using (Stream stream = assembly.GetManifestResourceStream(manifestResourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}