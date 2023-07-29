using Bogus;
using BusinessObjects.DataModels.Models;

namespace BusinessObjects.DataModels.Builders
{
    public static class ProjectDataModelBuilder
    {
        public static ProjectDataModel NewProjectModel()
        {
            var faker = new Faker();
            var model = new ProjectDataModel()
            {
                Name = $"{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Code = faker.Hacker.Abbreviation() + faker.Random.Number(0, 3000),
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
