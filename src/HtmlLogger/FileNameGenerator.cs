namespace HtmlLogger
{
    using HtmlLogger.Contracts;
    using HtmlLogger.Utils;
    using System;
    using System.IO;
    using System.Linq;

    using HtmlLogger.Model;

    internal class FileNameGenerator : IFileNameGenerator
    {
        #region Fields

        private const char FileNameSeparator = '-';

        private readonly LogDirectories _logDirectories;

        private readonly string _logfileNameFormat = "yyyy-MM-dd";
        private readonly string _logFolderNameFormat = "yyyy-MM-dd";
        private readonly string _screenShotfileNameFormat = "yyyy-MM-dd-mm-hh-ss";

        #endregion Fields

        #region Constructors

        public FileNameGenerator(LogDirectories logDirectories)
        {
            Guard.Against.Null(nameof(logDirectories), logDirectories);

            this._logDirectories = logDirectories;
        }

        #endregion Constructors

        #region Methods

        public string GetLogFileName()
        {
            var screenShotFileName = DateTime.Now.ToString(this._logfileNameFormat);

            return $"{screenShotFileName}.html";
        }

        public string GetScreenShotName()
        {
            var screenShotFileName = DateTime.Now.ToString(this._screenShotfileNameFormat);
            return $"{screenShotFileName}.png";
        }

        public string GetLogFolderName()
        {
            var screenShotFileName = DateTime.Now.ToString(this._logFolderNameFormat);

            var sequence = this.GetSequence();

            string maskedSequence = sequence.PadLeft(3, '0').Insert(0, FileNameSeparator.ToString());

            return $"{screenShotFileName}{maskedSequence}";
        }

        private string GetSequence()
        {
            var directory = new DirectoryInfo(this._logDirectories.CurrentLogDirectory);

            var lastLogFileInfo = directory.GetFiles("*.html").OrderByDescending(f => f.LastWriteTime).FirstOrDefault();

            //Default value is 1. In this case no html file represented in the folder.
            int sequenceNumber = 1;

            if (lastLogFileInfo != null)
            {
                string[] parts = lastLogFileInfo.Name.Split(FileNameSeparator);

                var lastPartOfName = parts.Last().Substring(0, 3);
                if (lastPartOfName.Length == 3)
                {
                    var lastSeq = Convert.ToInt32(lastPartOfName);
                    sequenceNumber = lastSeq + 1;
                }
            }

            return sequenceNumber.ToString();
        }

        #endregion Methods
    }
}