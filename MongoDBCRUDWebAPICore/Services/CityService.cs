using MongoDBCRUDWebAPICore.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MongoDBCRUDWebAPICore.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _cities;

        public CityService(IVirusDBDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cities = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<City> Get() =>
            _cities.Find(City => true).ToList();

        public City Get(string id) =>
            _cities.Find<City>(City => City.Id == id).FirstOrDefault();

        public City Create(City City)
        {
            _cities.InsertOne(City);
            return City;
        }

        public void Update(string id, City bookIn) =>
            _cities.ReplaceOne(City => City.Id == id, bookIn);

        public void Remove(City bookIn) =>
            _cities.DeleteOne(City => City.Id == bookIn.Id);

        public void Remove(string id) =>
            _cities.DeleteOne(City => City.Id == id);
    }
}