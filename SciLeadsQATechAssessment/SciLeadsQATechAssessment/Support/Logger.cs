using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Support
{
    public class Logger
    {
        /// <summary>
        /// Log an info level message
        /// </summary>
        /// <param name="message">Message to log</param>
        public void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        /// <summary>
        /// Log a warning level message
        /// </summary>
        /// <param name="message">Message to log</param>
        public void LogWarning(string message)
        {
            Console.WriteLine($"WARNING: {message}");
        }

        /// <summary>
        /// Log an error level message
        /// </summary>
        /// <param name="message">Message to log</param>
        public void LogError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }
    }
}
