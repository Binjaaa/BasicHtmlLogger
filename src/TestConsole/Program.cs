namespace TestConsole
{
    using HtmlLogger.Logger;
    using System;
    using System.IO;
    using System.Reflection;

    internal class Program
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private static void Main(string[] args)
        {
            StartTheFun();
        }

        private static void StartTheFun()
        {
            var templateFolderPath = AssemblyDirectory;
            var subDirName = "Template";

            var fullTemplateFolderPath = Path.Combine(templateFolderPath, subDirName);
            var fullDestinationFolderPath = Path.Combine(templateFolderPath, "Destination");

            MonkeyHtmlLogger logger = new MonkeyHtmlLogger(fullTemplateFolderPath, fullDestinationFolderPath);

            logger.LogInfo("QA1", true);
            logger.LogError("QA2", true);
            logger.LogWarning("QA3", true);

            logger.LogInfo("QA1NO", false);
            logger.LogError("QA2NO", false);
            logger.LogWarning("QA3NO", false);

            logger.AppendToRunDetails("foo1", "fooval1");
            logger.AppendToRunDetails("foo2", "fooval2");
            logger.AppendToRunDetails("foo3", "fooval3");
        }
    }
}