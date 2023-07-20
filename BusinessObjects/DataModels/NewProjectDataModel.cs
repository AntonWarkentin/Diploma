namespace BusinessObjects.DataModels
{
    public class NewProjectDataModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is NewProjectDataModel model &&
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
