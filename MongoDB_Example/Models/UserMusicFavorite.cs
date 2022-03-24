using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_Example.Models
{
    public class UserMusicFavorite
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id;
        public int userId;
        public List<Music> favorites;
    }
}
