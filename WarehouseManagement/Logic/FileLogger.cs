using System;
using System.IO;

namespace WarehouseManagement.Logic
{
    internal static class FileLogger
    {
        private const string LoggerFolderName = "ApplicationLogs";
        private const string LoggerFileName = "Logs.csv";

        internal static void AddLogExceptionToFile(string logMessage)
        {
            try
            {
                string directoryPath = string.Concat(Directory.GetCurrentDirectory(), "\\", LoggerFolderName);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string pathToFile = string.Concat(directoryPath, "\\", LoggerFileName);

                using (TextWriter textWriter = new StreamWriter(pathToFile, true))
                {
                    textWriter.WriteLine(string.Format("{0}|{1}", DateTime.Now.ToString(), logMessage));
                }
            }
            catch
            {
                Environment.Exit(1);
            }
        }
    }
}
