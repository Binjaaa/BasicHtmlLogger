namespace HtmlLogger.HtmlHelper
{
    using HtmlAgilityPack;

    public interface IHtmlHelper
    {
        #region Methods

        /// <summary>
        /// Add new row to the table in the html document.
        /// </summary>
        /// <param name="message"></param>
        void AddMessageRow(HtmlNode message);

        /// <summary>
        /// Add new row to the @RunDetails tbody element
        /// </summary>
        /// <param name="runDetailsNode"></param>
        void AppendToRunDetailsTable(HtmlNode runDetailsNode);

        #endregion Methods
    }
}