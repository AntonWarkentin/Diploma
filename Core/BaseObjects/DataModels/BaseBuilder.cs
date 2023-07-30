using NLog;

namespace Core.BaseObjects.DataModels
{
    public class BaseBuilder
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public BaseBuilder()
        {
            logger.Info("Preparing data for AT:");
        }
    }
}