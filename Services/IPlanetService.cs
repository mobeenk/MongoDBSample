using MongoDB.Driver;
using MongoDBAPI.Models;

namespace MongoDBAPI.Services
{
    public interface IPlanetService
    {
        List<Planet> Get();
        Planet Get(string id);
        Planet Create(Planet student);
        void Update(string id, Planet student);
        void Remove(string id);
    }
    public class PlanetService : IPlanetService
    {
        private readonly IMongoCollection<Planet> _students;

        public PlanetService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Planet>(settings.CollectionName);
        }

        public Planet Create(Planet student)
        {
            _students.InsertOne(student);
            return student;
        }

        public List<Planet> Get()
        {
            var res = _students.Find(student => true).ToList();
            return res;
        }

        public Planet Get(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(string id, Planet student)
        {
            _students.ReplaceOne(student => student.Id == id, student);
        }
    }
}
