namespace FataakAPI.Models
{
    public interface IFataakDatabaseSettings
    {
        public string FataakCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
