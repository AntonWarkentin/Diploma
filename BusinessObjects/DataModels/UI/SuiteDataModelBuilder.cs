using Bogus;

namespace BusinessObjects.DataModels.UI
{
    public class SuiteDataModelBuilder
    {
        public static SuiteDataModel NewSuiteModel()
        {
            var faker = new Faker();
            var model = new SuiteDataModel()
            {
                Name = $"TestSuite_{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Description = $"Descr_{faker.Hacker.Phrase()}",
                Preconditions = $"Precon_{faker.Hacker.Phrase()}",
            };

            return model;
        }
    }
}
