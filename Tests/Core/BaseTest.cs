using Allure.Commons;
using NLog;
using NUnit.Allure.Core;

namespace Tests.Core
{
    [AllureNUnit]
    public class BaseTest
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        protected AllureLifecycle allure;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            allure = AllureLifecycle.Instance;
        }

        [SetUp]
        public void SetUp()
        {
            logger.Info($"Starting execution of AT '{TestContext.CurrentContext.Test.FullName}'");
            
        }

        [TearDown]
        public void TearDown()
        {
            logger.Info($"Finishing execution of AT '{TestContext.CurrentContext.Test.FullName}'");
        }
    }
}
