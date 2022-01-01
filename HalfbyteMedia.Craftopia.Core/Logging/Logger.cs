using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfbyteMedia.Craftopia.Core.Logging
{
    public class Logger
    {
        public string LogDirectory { get; }
        public string LogName { get; }
        public string LogPath { get; private set; }

        public Logger(string logDirectory, string logName = "log.txt")
        {
            LogDirectory = logDirectory;
            LogName = logName;

            LogPath = Path.Combine(logDirectory, logName);

            InitializeLogger();
        }


        private void InitializeLogger()
        {
            try
            {
                if (!Directory.Exists(LogDirectory))
                    Directory.CreateDirectory(LogDirectory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetLogLine(string text, LogLevel logLevel)
        {            
            return $"[{DateTime.Now:G}][{logLevel}]: {text}{Environment.NewLine}";
        }

        public void WriteLine(string text, LogLevel logLevel)
        {
            var logLine = GetLogLine(text, logLevel);

            if (logLevel == LogLevel.ERROR) Console.Error.Write(logLine);
            else Console.Write(logLine);

            try
            {
                File.AppendAllText(LogPath, logLine);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void WriteInfo(string text)
        {
            WriteLine(text, LogLevel.INFO);
        }

        public void WriteDebug(string text)
        {
            WriteLine(text, LogLevel.DEBUG);
        }

        public void WriteWarn(string text)
        {
            WriteLine(text, LogLevel.WARN);
        }

        public void WriteError(string text)
        {
            WriteLine(text, LogLevel.ERROR);
        }

        public void WriteVerbose(string text)
        {
            WriteLine(text, LogLevel.VERBOSE);
        }
    }
}
