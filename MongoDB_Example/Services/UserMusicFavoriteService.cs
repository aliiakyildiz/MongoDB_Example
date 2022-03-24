using MongoDB.Driver;
using MongoDB_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_Example.Services
{
    public class UserMusicFavoriteService
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private readonly IMongoCollection<UserMusicFavorite> _musics;
        public UserMusicFavoriteService(IMongoDBSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
            _musics = _database.GetCollection<UserMusicFavorite>(settings.CollectionName);
        }

        public List<UserMusicFavorite> Get()
        {
            List<UserMusicFavorite> musics;
            musics = _musics.Find(fav => true).ToList();
            return musics;
        }
        public UserMusicFavorite GetByUserId(int userId)
        {
            return _musics.Find<UserMusicFavorite>(fav => fav.userId == userId).FirstOrDefault();
        }
        public void Remove(string id)
        {
            _musics.DeleteOne(m => m.id == id);
        }
        public UserMusicFavorite Create(UserMusicFavorite model)
        {
            _musics.InsertOne(model);
            return model;
        }
        public void Update(string id, UserMusicFavorite model)
        {
            _musics.ReplaceOne(m => m.id == id, model);
        }
    }
}
