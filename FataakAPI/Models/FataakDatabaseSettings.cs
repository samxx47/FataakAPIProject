namespace FataakAPI.Models
{
    public class FataakDatabaseSettings : IFataakDatabaseSettings
    {
        public string FataakCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get ; set ; }= string.Empty;
    }
}
