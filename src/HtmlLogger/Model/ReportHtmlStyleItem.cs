namespace HtmlLogger.Model
{
    internal class ReportHtmlStyleItem
    {
        #region Constructors

        public ReportHtmlStyleItem(string firstClassRow, string spanClass, string spanText)
        {
            this.FirstRowClass = firstClassRow;
            this.SpanClass = spanClass;
            this.SpanText = spanText;
        }

        #endregion Constructors

        #region Properties

        public string FirstRowClass { get; set; }

        public string SpanClass { get; set; }

        public string SpanText { get; set; }

        #endregion Properties
    }
}