namespace HtmlLogger
{
    using Contracts;
    using System.IO;

    internal class IoHelper : IIoHelper
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}