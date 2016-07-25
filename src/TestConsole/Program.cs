namespace TestConsole
{
    using HtmlLogger;
    using System;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Reflection;

    using HtmlLogger.Logger;

    internal class Program
    {
        private static void CaptureScreen()
        {
            ScreenCapturer sc = new ScreenCapturer();

            // capture entire screen and save it
            sc.CaptureScreenToFile("temp2.png", ImageFormat.Png);
        }

        private static void CaptureActualWindow()
        {
            ScreenCapturer sc = new ScreenCapturer();

            // capture this window, and save it
            sc.CaptureWindowToFile(sc.GetActiveWindowHandle(), "temp3.png", ImageFormat.Png);
        }

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

        private static void StartTheFun()
        {
            var templateFolderPath = AssemblyDirectory;
            var subDirName = "Template";
            var templateName = "report.html";

            var fullTemplateFilePath = Path.Combine(templateFolderPath, subDirName, templateName);

            MonkeyHtmlLogger logger = new MonkeyHtmlLogger(fullTemplateFilePath);

            logger.LogInfo("QA1", true);
            logger.LogError("QA2", true);
            logger.LogWarning("QA3", true);

            logger.LogInfo("QA1NO", false);
            logger.LogError("QA2NO", false);
            logger.LogWarning("QA3NO", false);
        }

        private static void Main(string[] args)
        {
            StartTheFun();
        }
    }
}