using Bogus;
using BusinessObjects.DataModels.Models;
using Core.BaseObjects.DataModels;
using System.Reflection;

namespace BusinessObjects.DataModels.Builders
{
    public class ProjectDataModelBuilder : BaseBuilder
    {
        public static ProjectDataModel NewProjectModel()
        {
            logger.Info("Preparing test data steps:");

            var faker = new Faker();
            var model = new ProjectDataModel()
            {
                Name = $"{faker.Hacker.Noun()} ({faker.Date.RecentTimeOnly()})",
                Code = faker.Hacker.Abbreviation() + faker.Random.Number(0, 3000),
                Description = faker.Hacker.Phrase()
            };

            logger.Info($"{MethodBase.GetCurrentMethod().Name}:{model.ToString()}");

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

            logger.Info($"{MethodBase.GetCurrentMethod().Name}:{model.ToString()}");

            return model;
        }
    }
}
