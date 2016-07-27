namespace HtmlLogger.Contracts
{
    public interface IIoHelper
    {
        bool FileExists(string filePath);

        bool DirectoryExists(string directoryPath);

        void CreateDirectoryIfNotExists(string directoryPath);

        string GetLatestFileName(string directory);
    }
}