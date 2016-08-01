namespace HtmlLogger.Contracts
{
    public interface IHtmlLogger
    {
        #region Methods

        void LogError(string message, bool isScreenShotNeeded);

        void LogInfo(string message, bool isScreenShotNeeded);

        #endregion Methods
    }
}