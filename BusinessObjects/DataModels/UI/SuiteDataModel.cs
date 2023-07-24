namespace BusinessObjects.DataModels.UI
{
    public class SuiteDataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Preconditions { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is SuiteDataModel model &&
                   Name == model.Name &&
                   Description == model.Description &&
                   Preconditions == model.Preconditions;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, Preconditions);
        }
    }
}
