namespace HtmlLogger.Model
{
    internal class ReportHtmlStyleItem
    {
        public ReportHtmlStyleItem(string firstClassRow, string spanClass, string spanText)
        {
            this.FirstRowClass = firstClassRow;
            this.SpanClass = spanClass;
            this.SpanText = spanText;
        }

        public string FirstRowClass { get; set; }

        public string SpanClass { get; set; }

        public string SpanText { get; set; }
    }
}