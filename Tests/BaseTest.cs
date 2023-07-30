using Core.SeleniumObjects.UI;
using NLog;

namespace Tests
{
    public class BaseTest
    {        
        protected Logger logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void SetUp()
        {
            logger.Info($"Starting execution of AT '{TestContext.CurrentContext.Test.FullName}'");
        }

        [TearDown]
        public void TearDown()
        {
            logger.Info($"Finishing execution of AT '{TestContext.CurrentContext.Test.FullName}'");
            Browser.Instance.CloseBrowser();
        }
    }
}
