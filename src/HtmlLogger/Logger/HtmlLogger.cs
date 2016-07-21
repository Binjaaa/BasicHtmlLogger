namespace HtmlLogger.Logger
{
    using HtmlHelper;
    using System;

    /// <summary>
    ///
    /// </summary>
    public sealed class HtmlLogger : HtmlLoggerBase
    {
        private readonly IHtmlHelper _htmlHelper;

        public override void LogError(string message, bool isScreenShotNeeded)
        {
            throw new NotImplementedException();
        }

        public override void LogInfo(string message, bool isScreenShotNeeded)
        {
            throw new NotImplementedException();
        }

        protected override void Log(string message, bool isScreenShotNeeded, Model.LogCategory category)
        {
            throw new NotImplementedException();
        }
    }
}