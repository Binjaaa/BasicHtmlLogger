namespace HtmlLogger.HtmlHelper
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.UI;

    public sealed class HtmlHelper : IHtmlHelper
    {
        public HtmlHelper(Uri savePath)
        {
            if (savePath == null)
            {
                throw new ArgumentNullException(nameof(savePath));
            }

            this.Path = savePath;
        }

        public Uri Path { get; }

        public void AddMessageRow(string message)
        {
            throw new NotImplementedException();
        }

        public void AddMessageRowWithImage(string message, Image image)
        {
            throw new NotImplementedException();
        }

        private void TryToInitHtmlFile(Uri savePath)
        {
            // Initialize StringWriter instance.
            StringWriter stringWriter = new StringWriter();

            var _words = new string[] { "a", "b", "c" };

            // Put HtmlTextWriter in using block because it needs to call Dispose.
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
            }
        }
    }
}
