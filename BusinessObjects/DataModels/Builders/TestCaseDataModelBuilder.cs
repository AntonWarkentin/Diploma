using Bogus;
using BusinessObjects.DataModels.Models;
using Core.BaseObjects.DataModels;
using System.Reflection;

namespace BusinessObjects.DataModels.Builders
{
    public class TestCaseDataModelBuilder : BaseBuilder
    {
        public static TestCaseModel NewTestCaseModel(bool needLogging = true)
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

            if (needLogging) logger.Info($"{MethodBase.GetCurrentMethod().Name}:{model.ToString()}");

            return model;
        }

        public static TestCasesBulkModel NewTestCasesBulkModel(int amountOfCases)
        {
            var model = new TestCasesBulkModel();
            model.Cases = new TestCaseModel[amountOfCases];

            for (int i = 0; i < amountOfCases; i++)
            {
                model.Cases[i] = NewTestCaseModel(false);
            }

            logger.Info($"{MethodBase.GetCurrentMethod().Name}:{model.ToString()}");

            return model;
        }
    }
}
