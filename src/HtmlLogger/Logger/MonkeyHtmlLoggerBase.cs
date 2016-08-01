namespace HtmlLogger.Logger
{
    using Contracts;
    using Model;

    public abstract class MonkeyHtmlLoggerBase : IHtmlLogger
    {
        #region Methods

        public abstract void LogError(string message, bool isScreenShotNeeded);

        public abstract void LogInfo(string message, bool isScreenShotNeeded);

        public abstract void LogWarning(string message, bool isScreenShotNeeded);

        protected abstract void Log(string message, bool isScreenShotNeeded, LogCategory category);

        #endregion Methods
    }
}