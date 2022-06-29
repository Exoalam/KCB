using MongoDB.Bson;
using MongoDB.Driver;

namespace KCB.Data
{
    public class DataBase
    {
        public string check_acc(string email, string password)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://nafiul005:nafiul005@database.tthhr5l.mongodb.net/?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("Users");
            var collection = database.GetCollection<BsonDocument>("UserLogin");
            var search = new BsonDocument { { "email", email }, { "password", password } };
            string check = collection.Find(search).FirstOrDefault().ToString();
            return check;
        }
        public void create_acc(string user, string email, string password)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://nafiul005:nafiul005@database.tthhr5l.mongodb.net/?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("Users");
            var collection = database.GetCollection<BsonDocument>("UserLogin");
            var document = new BsonDocument { { "user", user }, { "email", email }, { "password", password } };
            collection.InsertOne(document);
        }
      
    }
}
