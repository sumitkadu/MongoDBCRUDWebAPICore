namespace MongoDBCRUDWebAPICore.Models
{
    public class VirusDBDatabaseSettings : IVirusDBDatabaseSettings
    {
        public string CityCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IVirusDBDatabaseSettings
    {
        string CityCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}