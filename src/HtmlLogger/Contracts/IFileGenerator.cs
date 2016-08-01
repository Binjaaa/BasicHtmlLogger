namespace HtmlLogger.Contracts
{
    public interface IFileGenerator
    {
        #region Methods

        string GetLogFileName();

        string GetLogFilePath();

        string GetScreenShotFullPath();

        string GetScreenShotName();
        string GetTemplateFilePath();

        #endregion Methods
    }
}