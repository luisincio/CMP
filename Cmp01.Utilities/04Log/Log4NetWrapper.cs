using log4net;
using log4net.Config;
using System;

namespace Cmp01.Utilities.Log
{
    internal sealed class Log4NetWrapper: ILogger
    {
        readonly ILog _logManager;

        public Log4NetWrapper(Type type)
        {
            _logManager = LogManager.GetLogger(type);
        }

        public static void Configure()
        {
            XmlConfigurator.Configure();
        }

        #region Miembros Interfaz

        public void Info(string vMns)
        {
            _logManager.Info(vMns);
        }

        public void Debug(string vMns)
        {
            _logManager.Debug(vMns);
        }

        public void Error(string vMns)
        {
            _logManager.Error(vMns);
        }

        public void Error(string vMns, Exception ex)
        {
            _logManager.Error(vMns, ex);
        }

        #endregion
    }
}
