using System.Reflection;

namespace Cmp04.BusinessLogic
{
    public class Base
    {
        protected log4net.ILog Log
        {
            get { return log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().GetType()); }
        }
    }
}
