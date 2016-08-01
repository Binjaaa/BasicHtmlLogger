namespace HtmlLogger
{
    using HtmlLogger.Contracts;
    using HtmlLogger.Model;
    using HtmlLogger.Utils;
    using System;
    using System.IO;
    using System.Linq;

    internal class FileGenerator : IFileGenerator
    {
        #region Fields

        private const char FileNameSeparator = '-';
        private const string TemplateFileName = "report.html";

        private readonly string _destinationPath;
        private readonly IIoHelper _ioHelper;
        private readonly LogDirectories _logDirectories;

        private readonly string _logfileNameFormat = "yyyy-MM-dd";
        private readonly string _logFolderNameFormat = "yyyy-MM-dd";
        private readonly string _screenShotfileNameFormat = "yyyy-MM-dd-mm-hh-ss";

        private readonly string _templatePath;

        #endregion Fields

        #region Constructors

        public FileGenerator(string templatePath, string destinationPath, IIoHelper ioHelper)
        {
            Guard.Against.NullOrEmpty(nameof(templatePath), templatePath);
            Guard.Against.NullOrEmpty(nameof(destinationPath), destinationPath);
            Guard.Against.Null(nameof(ioHelper), ioHelper);

            this._templatePath = templatePath;
            this._destinationPath = destinationPath;
            this._ioHelper = ioHelper;

            this._logDirectories = this.EnsureFolderStructure(destinationPath);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the log file name.
        /// Example: 2016-09-01.html
        /// </summary>
        /// <returns></returns>
        public string GetLogFileName()
        {
            var screenShotFileName = DateTime.Now.ToString(this._logfileNameFormat);

            return $"{screenShotFileName}.html";
        }

        public string GetLogFilePath()
        {
            return Path.Combine(this._logDirectories.CurrentLogDirectory, this.GetLogFileName());
        }

        public string GetScreenShotFullPath()
        {
            return this._logDirectories.ScreenshotFolder;
        }

        public string GetScreenShotName()
        {
            var screenShotFileName = DateTime.Now.ToString(this._screenShotfileNameFormat);
            return $"{screenShotFileName}.png";
        }

        public string GetTemplateFilePath()
        {
            return Path.Combine(this._templatePath, TemplateFileName);
        }

        private LogDirectories EnsureFolderStructure(string destinationFolder)
        {
            //Ensure "Destination" folder is exists
            var destinationPath = this._ioHelper.CreateDirectoryIfNotExists(destinationFolder);

            //Create actual log folder
            var logFolder = this._ioHelper.CreateDirectoryIfNotExists(Path.Combine(destinationFolder, this.GetLogFolderName()));

            //Create screenshots folder in log folder
            var screenShotFolder = this._ioHelper.CreateDirectoryIfNotExists(Path.Combine(logFolder, "screenshots"));

            return new LogDirectories()
            {
                CurrentLogDirectory = logFolder,
                ScreenshotFolder = screenShotFolder
            };
        }

        private string GetLogFolderName()
        {
            var logFolderName = DateTime.Now.ToString(this._logFolderNameFormat);

            var sequence = this.GetSequence();

            string maskedSequence = sequence.PadLeft(3, '0').Insert(0, FileNameSeparator.ToString());

            return $"{logFolderName}{maskedSequence}";
        }

        private string GetSequence()
        {
            var directory = new DirectoryInfo(this._destinationPath);

            var lastLogDirInfo = directory.GetDirectories()
                                          .OrderByDescending(f => f.LastWriteTime)
                                          .FirstOrDefault();

            //Default value is 1.
            int sequenceNumber = 1;
            string todayFormat = DateTime.Now.ToString(this._logFolderNameFormat);

            if (lastLogDirInfo != null && lastLogDirInfo.Name.StartsWith(todayFormat))
            {
                string[] parts = lastLogDirInfo.Name.Split(FileNameSeparator);

                var lastPartOfName = parts.Last();
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