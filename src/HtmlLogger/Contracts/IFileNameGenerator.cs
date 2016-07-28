namespace HtmlLogger.Contracts
{
    public interface IFileNameGenerator
    {
        string GetScreenShotName();

        string GetLogFileName();

        string GetLogFolderName();
    }
}