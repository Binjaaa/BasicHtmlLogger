namespace HtmlLogger
{
    using Contracts;
    using System.IO;
    using System.Linq;

    internal class IoHelper : IIoHelper
    {
        #region Methods

        public string CreateDirectoryIfNotExists(string directoryPath)
        {
            if (!this.DirectoryExists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }

        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string GetLatestFileName(string directoryPath)
        {
            var directory = new DirectoryInfo(directoryPath);
            var logName = directory.GetFiles("*.html").OrderByDescending(f => f.LastWriteTime).FirstOrDefault();

            return logName?.Name;
        }

        #endregion Methods
    }
}