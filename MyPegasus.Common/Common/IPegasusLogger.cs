using System;

namespace MyPegasus.Common.Common
{
    public interface IPegasusLogger
    {
        void LogException(Exception ex, string message = null);
        void LogWarning(string message);
        void LogInfo(string message);
    }
}
