namespace HtmlLogger.Contracts
{
    public interface IIoHelper
    {
        bool FileExists(string filePath);

        bool DirectoryExists(string directoryPath);

        string CreateDirectoryIfNotExists(string directoryPath);

        string GetLatestFileName(string directory);
    }
}