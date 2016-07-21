namespace HtmlLogger.Logger
{
    using Contracts;

    public abstract class HtmlLoggerBase : IHtmlLogger
    {
        protected abstract void Log(string message, bool isScreenShotNeeded, Model.LogCategory category);

        public abstract void LogError(string message, bool isScreenShotNeeded);

        public abstract void LogInfo(string message, bool isScreenShotNeeded);
    }
}