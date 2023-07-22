﻿using Bogus;

namespace BusinessObjects.DataModels
{
    public static class NewProjectDataModelBuilder
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