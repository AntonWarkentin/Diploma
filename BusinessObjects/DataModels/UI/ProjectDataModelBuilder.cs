using Bogus;

namespace BusinessObjects.DataModels.UI
{
    public static class ProjectDataModelBuilder
    {
        public static ProjectDataModel NewProjectModel()
        {
            var faker = new Faker();
            var model = new ProjectDataModel()
            {
                Name = $"{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Code = faker.Hacker.Abbreviation() + faker.Random.Number(),
                Description = faker.Hacker.Phrase()
            };

            return model;
        }

        public static ProjectDataModel UpdateProjectModel()
        {
            var faker = new Faker();
            var model = new ProjectDataModel()
            {
                Name = $"updated_{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Description = $"updated_{faker.Hacker.Phrase()}"
            };

            return model;
        }
    }
}
