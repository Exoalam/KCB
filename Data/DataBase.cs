using MongoDB.Bson;
using MongoDB.Driver;

namespace KCB.Data
{
    public class DataBase
    {
        public string start_server()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://nafiul005:nafiul005@database.tthhr5l.mongodb.net/?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("Users");
            var collection = database.GetCollection<BsonDocument>("UserLogin");
            var document = new BsonDocument { { "student_id", 10000 }, {
                "scores",
                new BsonArray {
                new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                }
                }, { "class_id", 480 }
            };
            collection.InsertOne(document);
            return "hello";
        }
      
    }
}
