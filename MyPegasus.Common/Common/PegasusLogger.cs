using System;
using System.Diagnostics;

namespace MyPegasus.Common.Common
{
    public class PegasusLogger : IPegasusLogger
    {
        public void LogException(Exception ex, string message = "An exception occurred")
        {
            Trace.TraceError($"{message}: {ex.Message} - {ex.StackTrace}");
        }

        public void LogWarning(string message)
        {
            Trace.TraceWarning($"Pegasus warning: {message}");
        }

        public void LogInfo(string message)
        {
            Trace.TraceInformation($"Pegasus warning: {message}");
        }
    }
}
