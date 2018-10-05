using System;

namespace Cmp01.Utilities.Log
{
    public interface ILogger
    {
        void Debug(string vMns);
        void Error(string vMns);
        void Error(string vMns, Exception ex);
        void Info(string vMns);
    }
}
