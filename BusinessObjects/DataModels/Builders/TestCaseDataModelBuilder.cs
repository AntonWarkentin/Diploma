using Bogus;
using BusinessObjects.DataModels.Models;

namespace BusinessObjects.DataModels.Builders
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
                LayerStr = "E2E",
                IsFlakyStr = "Yes",
                BehaviorStr = "Negative",
                Behavior = 1,
                AutomationStatus = "To be automated",
                Preconditions = $"Precon_{faker.Hacker.Phrase()}",
                Postconditions = $"Postcon_{faker.Hacker.Phrase()}",
            };

            return model;
        }

        public static TestCasesBulkModel NewTestCasesBulkModel(int amountOfCases)
        {
            var cases = new TestCasesBulkModel();
            cases.Cases = new TestCaseModel[amountOfCases];

            for (int i = 0; i < amountOfCases; i++)
            {
                cases.Cases[i] = NewTestCaseModel();
            }

            return cases;
        }
    }
}
