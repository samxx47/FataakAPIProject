using FataakAPI.Models;
using MongoDB.Driver;

namespace FataakAPI.Services
{
    public class FataakService : IFataakService
    {
        private readonly IMongoCollection<Fataak> _ftk;

        public FataakService(IFataakDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _ftk = database.GetCollection<Fataak>(settings.FataakCollectionName);
        }
        public Fataak Create(Fataak ftk)
        {
            ftk.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            _ftk.InsertOne(ftk);
            return ftk;
        }

        public List<Fataak> Get()
        {
            return _ftk.Find(ftk => true).ToList();
        }

        public Fataak Get(string id)
        {
            return _ftk.Find(f => f.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _ftk.DeleteOne(partner => partner.Id == id);
        }

        public void Update(string id, Fataak ftk)
        {
            _ftk.ReplaceOne(f => f.Id == id, ftk);
        }
    }
}
