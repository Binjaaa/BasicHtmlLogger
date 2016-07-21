namespace HtmlLogger.Contracts
{
    public interface IHtmlLogger
    {
        void LogInfo(string message, bool isScreenShotNeeded);

        void LogError(string message, bool isScreenShotNeeded);
    }
}