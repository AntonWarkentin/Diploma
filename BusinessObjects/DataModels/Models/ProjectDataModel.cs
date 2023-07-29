namespace BusinessObjects.DataModels.Models
{
    public class ProjectDataModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ProjectDataModel model &&
                   Name == model.Name &&
                   Code == model.Code &&
                   Description == model.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Code, Description);
        }
    }
}
