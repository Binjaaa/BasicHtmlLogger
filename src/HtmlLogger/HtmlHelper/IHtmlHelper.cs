namespace HtmlLogger.HtmlHelper
{
    using HtmlAgilityPack;

    public interface IHtmlHelper
    {
        /// <summary>
        /// Add new row to the table in the html document.
        /// </summary>
        /// <param name="message"></param>
        void AddMessageRow(HtmlNode message);
    }
}