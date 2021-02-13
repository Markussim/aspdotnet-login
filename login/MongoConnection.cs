using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;


namespace login
{
    class MongoConnection
    {
        public static IMongoCollection<BsonDocument> collection;
        public static void ConnectToDB()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017/");
            IMongoDatabase database = dbClient.GetDatabase("LoginSystem");
            collection = database.GetCollection<BsonDocument>("accounts");
        }

        public static void InsertToDB(AccountModel doc)
        {
            var returnDoc = new BsonDocument { { "Name", doc.Name }, { "Pass", doc.Pass }};
            collection.InsertOne(returnDoc);
        }

        public static IEnumerable<AccountModel> GetInDB()
        {
            var DBList = collection.Find(new BsonDocument()).ToList();

            var AccountList = new List<AccountModel>();

            foreach (var item in DBList)
            {
                AccountList.Add(new AccountModel(item["Name"].AsString, item["Pass"].AsString));
            }

            return AccountList;
        }
    }
}