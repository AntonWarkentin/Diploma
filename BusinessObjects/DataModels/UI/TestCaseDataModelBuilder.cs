using Bogus;
using BusinessObjects.DataModels.API;

namespace BusinessObjects.DataModels.UI
{
    public class TestCaseDataModelBuilder
    {
        public static TestCaseModel NewTestCaseModel()
        {
            var faker = new Faker();
            var model = new TestCaseModel()
            {
                Title = $"TestCase_{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Status = "Draft",
                Description = $"Descr_{faker.Hacker.Phrase()}",
                SeverityStr = "Major",
                PriorityStr = "Medium",
                Type = "Security",
                Layer = "E2E",
                IsFlakyStr = "Yes",
                Behavior = "Negative",
                AutomationStatus = "To be automated",
                Preconditions = $"Precon_{faker.Hacker.Phrase()}",
                Postconditions = $"Postcon_{faker.Hacker.Phrase()}",
            };

            return model;
        }
    }
}
