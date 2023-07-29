using Bogus;
using BusinessObjects.DataModels.Models;

namespace BusinessObjects.DataModels.Builders
{
    public class DefectDataModelBuilder
    {
        public static DefectDataModel CreateDefectModel()
        {
            var faker = new Faker();
            var model = new DefectDataModel()
            {
                Title = $"Defect_{faker.Hacker.Adjective()}-{faker.Date.RecentTimeOnly()}",
                ActualResult = $"def_{faker.Hacker.Phrase()}-{faker.Date.RecentTimeOnly()}",
                Severity = $"{faker.Random.Int(0, 6)}",
            };

            return model;
        }
        
        public static DefectDataModel UpdateDefectModel()
        {
            var faker = new Faker();
            var model = new DefectDataModel()
            {
                Title = $"upd_Defect_{faker.Hacker.Adjective()}-{faker.Date.RecentTimeOnly()}",
                ActualResult = $"upd_def_{faker.Hacker.Phrase()}-{faker.Date.RecentTimeOnly()}",
                Severity = $"{faker.Random.Int(0, 6)}",
            };

            return model;
        }
    }
}
