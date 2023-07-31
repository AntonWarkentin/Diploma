using Core.Helpers;
using Core.SeleniumObjects.UI;

namespace Tests.Core
{
    public class BaseUITest : BaseTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                var screenShot = Browser.Instance.Driver.TakeScreenShot();
                allure.AddAttachment("File", "image/png", screenShot.AsByteArray);
            }

            Browser.Instance.CloseBrowser();
        }
    }
}
