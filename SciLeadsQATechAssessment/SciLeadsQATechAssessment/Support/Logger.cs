namespace SciLeadsQATechAssessment.Tests.UI.Support
{
    /// <summary>
    /// Class for writing log messages.
    /// </summary>
    public class Logger
    {
        private readonly string LOGLOCATION = @"C:\Log";
        private string logFileName = "";

        private static Logger? _instance;
        public static Logger Instance
        { 
            get 
            {
                if (_instance == null)
                { 
                    _instance = new Logger();
                }

                return _instance; 
            }
        }
        
        private Logger()
        {
            if (!Directory.Exists(LOGLOCATION))
            {
                Directory.CreateDirectory(LOGLOCATION);
            }

            logFileName = $"{LOGLOCATION}\\TestLog_{DateTime.Now:yyyyMMddhhmmss}.txt";
            
            File.Create(logFileName).Close();
        }
        /// <summary>
        /// Log an info level message
        /// </summary>
        /// <param name="message">Message to log</param>
        public void LogInfo(string message)
        {
            WriteMessaeToConsoleAndFile($"INFO: {message}");
        }

        /// <summary>
        /// Log a warning level message
        /// </summary>
        /// <param name="message">Message to log</param>
        public void LogWarning(string message)
        {
            WriteMessaeToConsoleAndFile($"WARNING: {message}");
        }

        /// <summary>
        /// Log an error level message
        /// </summary>
        /// <param name="message">Message to log</param>
        public void LogError(string message)
        {
            WriteMessaeToConsoleAndFile($"ERROR: {message}");
        }

        private void WriteMessaeToConsoleAndFile(string message)
        { 
            Console.WriteLine(message);
            File.AppendAllText(logFileName, message + "\n");
        }
    }
}
