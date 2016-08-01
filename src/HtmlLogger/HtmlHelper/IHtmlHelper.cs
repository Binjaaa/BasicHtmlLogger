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

        #endregion Methods
    }
}