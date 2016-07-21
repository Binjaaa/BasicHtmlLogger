namespace HtmlLogger.HtmlHelper
{
    using System;
    using System.Drawing;

    public interface IHtmlHelper
    {
        /// <summary>
        /// Path of the destination html file.
        /// </summary>
        Uri Path { get; }

        void AddMessageRow(string message);

        void AddMessageRowWithImage(string message, Image image);
    }
}