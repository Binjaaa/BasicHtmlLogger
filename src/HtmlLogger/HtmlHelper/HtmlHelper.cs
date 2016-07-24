namespace HtmlLogger.HtmlHelper
{
    using Contracts;
    using HtmlAgilityPack;
    using System;
    using System.IO;
    using Utils;

    public sealed class HtmlHelper : IHtmlHelper
    {
        private static HtmlDocument _html = new HtmlDocument();
        private readonly IIoHelper _ioHelper;

        public HtmlHelper(IIoHelper ioHelper, string templateFullPath)
        {
            Guard.Against.Null(nameof(ioHelper), ioHelper);
            Guard.Against.Null(nameof(templateFullPath), templateFullPath);

            if (!File.Exists(templateFullPath))
            {
                throw new Exception($"The file at the following path is not existing: {templateFullPath}");
            }

            this._ioHelper = ioHelper;
            this.TemplatePath = templateFullPath;

            this.InitHtmlDocument(templateFullPath);
        }

        public string TemplatePath { get; }

        public void AddMessageRow(HtmlNode message)
        {
            GetTableBodyElement().AppendChild(message);

            _html.Save("mukodj");
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