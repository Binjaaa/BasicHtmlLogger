namespace HtmlLogger.Contracts
{
    public interface IFileGenerator
    {
        string GetScreenShotName();

        string GetScreenShotFullPath();

        string GetLogFileName();

        string GetTemplateFilePath();

        string GetLogFilePath();
    }
}