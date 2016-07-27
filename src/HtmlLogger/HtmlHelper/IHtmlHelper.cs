namespace HtmlLogger.HtmlHelper
{
    using HtmlAgilityPack;

    public interface IHtmlHelper
    {
        /// <summary>
        /// Folder path of the template file
        /// </summary>
        string TemplatePath { get; }

        /// <summary>
        /// Destination folder path of the generated log file
        /// </summary>
        string DestinationPath { get; }

        /// <summary>
        /// Add new row to the table in the html document.
        /// </summary>
        /// <param name="message"></param>
        void AddMessageRow(HtmlNode message);
    }
}