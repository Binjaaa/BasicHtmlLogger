namespace HtmlLogger.HtmlHelper
{
    using System;
    using Contracts;
    using HtmlAgilityPack;
    using Utils;

    public sealed class HtmlHelper : IHtmlHelper
    {
        #region Fields

        private static readonly HtmlDocument _html = new HtmlDocument();

        private readonly IFileGenerator _fileGenerator;

        #endregion Fields

        #region Constructors

        public HtmlHelper(IFileGenerator fileGenerator)
        {
            Guard.Against.Null(nameof(fileGenerator), fileGenerator);

            this._fileGenerator = fileGenerator;

            this.InitHtmlDocument();
        }

        #endregion Constructors

        #region Methods

        public void AddMessageRow(HtmlNode message)
        {
            this.GetTableBodyElement().AppendChild(message);

            this.SaveHtmlChanges();
        }

        public void AppendToRunDetailsTable(HtmlNode runDetailsNode)
        {
            this.GetRunDetailsElement().AppendChild(runDetailsNode);

            this.SaveHtmlChanges();
        }

        private HtmlNode GetTableBodyElement()
        {
            return _html.DocumentNode.SelectSingleNode("//tbody");
        }

        private HtmlNode GetRunDetailsElement()
        {
            return _html.DocumentNode.SelectSingleNode("//tbody[@class='runDetails']");
        }

        private void InitHtmlDocument()
        {
            var reportTemplatePath = this._fileGenerator.GetTemplateFilePath();

            _html.Load(reportTemplatePath);
        }

        private void SaveHtmlChanges()
        {
            var fullReportPath = this._fileGenerator.GetLogFilePath();

            _html.Save(fullReportPath);
        }
        #endregion Methods
    }
}