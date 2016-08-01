namespace HtmlLogger.Contracts
{
    using HtmlAgilityPack;
    using HtmlLogger.Model;

    public interface INodeCreator
    {
        #region Methods

        HtmlNode CreateNode(string message, bool isScreenShotNeeded, LogCategory logCategory);

        #endregion Methods
    }
}