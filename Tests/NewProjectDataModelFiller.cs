using Bogus;
using BusinessObjects.DataModels;

namespace Tests
{
    public static class NewProjectDataModelFiller
    {
        public static NewProjectDataModel CreateProjectWithFakedValues()
        {
            var faker = new Faker();
            var model = new NewProjectDataModel()
            {
                Name = $"{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Code = faker.Hacker.Abbreviation() + faker.Random.Number(),
                Description = faker.Hacker.Phrase()
            };

            return model;
        }
    }
}
