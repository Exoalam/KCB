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
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                if(email == doc["email"])
                {
                    if(password == doc["password"])
                    {
                        return doc["user"].ToString();
                    }
                }
            }
            return "W";
            
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
