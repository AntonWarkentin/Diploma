using Bogus;
using BusinessObjects.DataModels.Models;

namespace BusinessObjects.DataModels.Builders
{
    public class SuiteDataModelBuilder
    {
        public static SuiteDataModel NewSuiteModel()
        {
            var faker = new Faker();
            var model = new SuiteDataModel()
            {
                Title = $"TestSuite_{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Description = $"Descr_{faker.Hacker.Phrase()}",
                Preconditions = $"Precon_{faker.Hacker.Phrase()}",
            };

            return model;
        }

        public static SuiteDataModel UpdateSuiteModel()
        {
            var faker = new Faker();
            var model = new SuiteDataModel()
            {
                Title = $"upd_TestSuite_{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Description = $"upd_Descr_{faker.Hacker.Phrase()}",
                Preconditions = $"upd_Precon_{faker.Hacker.Phrase()}",
            };

            return model;
        }
    }
}
