namespace HtmlLogger.Logger
{
    using Model;
    using System;
    using System.Collections.Generic;

    internal static class HtmlAttributeHelper
    {
        #region Fields

        private static readonly Dictionary<LogCategory, ReportHtmlStyleItem> _classSet = new Dictionary<LogCategory, ReportHtmlStyleItem>()
        {
            { LogCategory.Info,  new ReportHtmlStyleItem(string.Empty,"default","Info") },
            { LogCategory.Warning,  new ReportHtmlStyleItem("class=\"warning\"","warning","Warning") },
            { LogCategory.Danger,  new ReportHtmlStyleItem("class=\"danger\"","danger","Error") }
        };

        #endregion Fields

        #region Methods

        internal static ReportHtmlStyleItem GetStyleByCategory(LogCategory category)
        {
            switch (category)
            {
                case LogCategory.Info:
                case LogCategory.Warning:
                case LogCategory.Danger:
                    return _classSet[category];

                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        #endregion Methods
    }
}