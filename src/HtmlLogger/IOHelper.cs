namespace HtmlLogger
{
    using Contracts;
    using System;
    using System.Drawing;
    using System.IO;

    internal class IoHelper : IIoHelper
    {
        public bool FileExists(Uri filePath)
        {
            return File.Exists(filePath.AbsolutePath);
        }

        public void SavePictureTo(Image image, string path)
        {
            //TODO: Format is: screenshots/2016-07-22_10-26-02.png
        }
    }
}