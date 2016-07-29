namespace HtmlLogger.HtmlHelper
{
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

            var fullReportPath = this._fileGenerator.GetLogFilePath();

            _html.Save(fullReportPath);
        }

        private HtmlNode GetTableBodyElement()
        {
            return _html.DocumentNode.SelectSingleNode("//tbody");
        }

        private void InitHtmlDocument()
        {
            var reportTemplatePath = this._fileGenerator.GetTemplateFilePath();

            _html.Load(reportTemplatePath);
        }

        #endregion Methods
    }
}