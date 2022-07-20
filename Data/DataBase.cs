using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace KCB.Data
{
    public class DataBase
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://nafiul005:nafiul005@database.tthhr5l.mongodb.net/?retryWrites=true&w=majority");
        public string check_acc(string email, string password)
        {

            var database = dbClient.GetDatabase("Users");
            var collection = database.GetCollection<BsonDocument>("UserLogin");
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                if (email == doc["email"])
                {
                    if (password == doc["password"])
                    {

                        return doc["user"].ToString();
                    }
                }
            }
            return "W";

        }
        public string create_acc(string user, string email, string password)
        {
            var database = dbClient.GetDatabase("Users");
            var collection = database.GetCollection<BsonDocument>("UserLogin");
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                if (user == doc["user"])
                {
                    return "ID already exists";
                }
                else
                {
                    if (email == doc["email"])
                    {
                        return "Email already exists";
                    }
                }
            }
            var document = new BsonDocument { { "user", user }, { "email", email }, { "password", password } };
            collection.InsertOne(document);
            return "Account created";
        }

        public int get_tid()
        {
            int tid = 0;
            var database = dbClient.GetDatabase("Transaction");
            var collection = database.GetCollection<BsonDocument>("transaction_history");
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                tid = doc["t_id"].ToInt32();
            }
            tid++;
            return tid;
        }
        public void add_transaction(string user, string paytype, string account, string amount, string feetype)
        {
            var database = dbClient.GetDatabase("Transaction");
            var collection = database.GetCollection<BsonDocument>("transaction_history");
            var document = new BsonDocument { { "user", user }, { "t_id", get_tid() }, { "type", paytype }, { "t_acc", account }, { "amount", int.Parse(amount) }, { "fee_type", feetype } };
            collection.InsertOne(document);
        }

        public string get_img()
        {
            string img = "";
            var database = dbClient.GetDatabase("Faculty");
            var collection = database.GetCollection<BsonDocument>("Teachers");
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                img = doc["img"].ToString();
            }
            return img;
        }

        public BsonDocument get_result(string user, string session)
        {
            var database = dbClient.GetDatabase("Academic_Record");
            var collection = database.GetCollection<BsonDocument>("Results");
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                if (doc["user"] == user)
                {
                    try
                    {
                        if (doc[session] != null)
                        {
                            return doc[session].ToBsonDocument();
                        }
                    }
                    catch
                    {

                    }

                }
            }
            var result = new BsonDocument { { "SESSION", "NO DATA" } };
            return result;
        }
        public BsonDocument grade()
        {
            var database = dbClient.GetDatabase("Academic_Record");
            var collection = database.GetCollection<BsonDocument>("GRADE");
            var documents = collection.Find(new BsonDocument()).ToList();
            return documents[0].ToBsonDocument();
        }
        public ArrayList get_notice(string type)
        {
            var arlist = new ArrayList();
            var database = dbClient.GetDatabase("Notice");
            var collection = database.GetCollection<BsonDocument>(type);
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                arlist.Add(doc["name"].ToString());
            }
            return arlist;
        }
    }

}
