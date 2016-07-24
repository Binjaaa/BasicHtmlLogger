namespace HtmlLogger.HtmlHelper
{
    using HtmlAgilityPack;

    public interface IHtmlHelper
    {
        /// <summary>
        /// Path of the destination html file.
        /// </summary>
        string TemplatePath { get; }

        /// <summary>
        /// Add new row to the table in the html document.
        /// </summary>
        /// <param name="message"></param>
        void AddMessageRow(HtmlNode message);
    }
}