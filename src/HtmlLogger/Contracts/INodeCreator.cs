namespace HtmlLogger.Contracts
{
    using HtmlAgilityPack;
    using HtmlLogger.Model;

    public interface INodeCreator
    {
        #region Methods

        HtmlNode CreateNode(string message, bool isScreenShotNeeded, LogCategory logCategory);

        HtmlNode CreateDetailsNode(string name, string value);

        #endregion Methods
    }
}