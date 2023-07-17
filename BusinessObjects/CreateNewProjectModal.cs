using OpenQA.Selenium;
using Bogus;
using NUnit.Framework;

namespace BusinessObjects
{
    public class CreateNewProjectModal : ProjectsPage
    {
        private By ProjectNameInput = By.XPath("//input[@id='project-name']");
        private By ProjectCodeInput = By.XPath("//input[@id='project-code']");
        private By ProjectDescriptionArea = By.XPath("//textarea[@id='description-area']");

        private By PrivateRadioButton = By.XPath("//input[@value='private']");
        private By PublicRadioButton = By.XPath("//input[@value='public']");

        private By AddAllMembersRadioButton = By.XPath("//input[@value='all']");
        private By AddMembersFromGroupRadioButton = By.XPath("//input[@value='group']");
        private By DontAddMembersRadioButton = By.XPath("//input[@value='none']");

        private By SubmitButton = By.XPath("//button[@type='submit']");

        public ProjectPage CreateNewProject()
        {
            var faker = new Faker();
            var code = faker.Hacker.Abbreviation();

            driver.FindElement(ProjectNameInput).SendKeys(faker.Hacker.Noun());

            driver.FindElement(ProjectCodeInput).Clear();
            driver.FindElement(ProjectCodeInput).SendKeys(code);

            var privateRadioButton = driver.FindElement(PrivateRadioButton);
            var publicRadioButton = driver.FindElement(PublicRadioButton);
            publicRadioButton.Click();
            Assert.IsTrue(publicRadioButton.Selected);
            Assert.IsFalse(privateRadioButton.Selected);

            driver.FindElement(SubmitButton).Click();

            return new ProjectPage(code);
        }
    }
}