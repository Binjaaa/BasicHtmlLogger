namespace HtmlLogger.HtmlHelper
{
    using Contracts;
    using HtmlAgilityPack;
    using System;
    using System.IO;
    using Utils;

    public sealed class HtmlHelper : IHtmlHelper
    {
        private static readonly HtmlDocument _html = new HtmlDocument();
        private readonly IIoHelper _ioHelper;

        private string _templatePath;
        private string _destinationPath;

        private const string _templateName = "report.html";

        public HtmlHelper(IIoHelper ioHelper, string templateFullPath, string destinationPath)
        {
            Guard.Against.Null(nameof(ioHelper), ioHelper);
            Guard.Against.NullOrEmpty(nameof(templateFullPath), templateFullPath);
            Guard.Against.NullOrEmpty(nameof(destinationPath), destinationPath);

            this._ioHelper = ioHelper;
            this.TemplatePath = templateFullPath;

            this._ioHelper.CreateDirectoryIfNotExists(destinationPath);
            this.InitHtmlDocument(Path.Combine(templateFullPath, _templateName));
        }

        public string TemplatePath
        {
            get
            {
                return this._templatePath;
            }
            private set
            {
                if (!this._ioHelper.DirectoryExists(value))
                {
                    throw new ArgumentException($"The given {nameof(this.TemplatePath)} is not existing: {value}");
                }

                this._templatePath = value;
            }
        }

        public string DestinationPath
        {
            get
            {
                return this._destinationPath;
            }
            private set
            {
                if (!this._ioHelper.DirectoryExists(value))
                {
                    throw new ArgumentException($"The given {nameof(this.DestinationPath)} is not existing: {value}");
                }

                this._destinationPath = value;
            }
        }

        public void AddMessageRow(HtmlNode message)
        {
            this.GetTableBodyElement().AppendChild(message);

            var reportName = $"MonkeyReport_{DateTime.Now.ToShortDateString()}.html";
            var fullReportPath = Path.Combine();

            _html.Save();
        }

        private HtmlNode GetTableBodyElement()
        {
            return _html.DocumentNode.SelectSingleNode("//tbody");
        }

        private void InitHtmlDocument(string templateFullPath)
        {
            _html.Load(templateFullPath);
        }
    }
}