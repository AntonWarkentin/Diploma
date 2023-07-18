﻿using OpenQA.Selenium;
using Bogus;
using BusinessObjects.ElementsObjects;

namespace BusinessObjects.PageObjects
{
    public class CreateNewProjectModal : ProjectsPage
    {
        private By ProjectNameInput = By.XPath("//input[@id='project-name']");
        private By ProjectCodeInput = By.XPath("//input[@id='project-code']");
        private By ProjectDescriptionArea = By.XPath("//textarea[@id='description-area']");

        private By SubmitButton = By.XPath("//button[@type='submit']");

        private ProjectAccessTypeRadioButtons projectAccess = new ();
        private MemberAccessTypeRadioButtons memberAccess = new ();

        public ProjectPage CreateNewProject()
        {
            var faker = new Faker();
            var code = faker.Hacker.Abbreviation();

            driver.FindElement(ProjectNameInput).SendKeys(faker.Hacker.Noun());

            driver.FindElement(ProjectCodeInput).Clear();
            driver.FindElement(ProjectCodeInput).SendKeys(code);

            memberAccess.CheckOneOption(MemberAccessOptions.AddMembersFromGroupRadioButton);

            driver.FindElement(SubmitButton).Click();

            return new ProjectPage(code);
        }
    }
}