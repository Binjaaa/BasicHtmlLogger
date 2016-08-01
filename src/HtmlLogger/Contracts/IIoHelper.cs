namespace HtmlLogger.Contracts
{
    public interface IIoHelper
    {
        #region Methods

        string CreateDirectoryIfNotExists(string directoryPath);

        bool DirectoryExists(string directoryPath);

        bool FileExists(string filePath);
        string GetLatestFileName(string directory);

        #endregion Methods
    }
}