namespace HtmlLogger.Contracts
{
    using System;
    using System.Drawing;

    public interface IIoHelper
    {
        bool FileExists(Uri filePath);

        void SavePictureTo(Image image, string path);
    }
}