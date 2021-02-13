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
            collection.InsertOne(doc.ToBson());
        }

        public static IEnumerable<AccountModel> GetInDB(AccountModel User)
        {
            List<BsonDocument> DBList;

            if (User == null)
            {
                System.Console.WriteLine("null");
                DBList = collection.Find(new BsonDocument()).ToList();
            } else
            {
                DBList = collection.Find(new BsonDocument(User.ToBson())).ToList();
            }



            var AccountList = new List<AccountModel>();

            foreach (var item in DBList)
            {
                AccountModel account = new AccountModel();

                account.Name = item["Name"].AsString;

                account.Pass = item["Pass"].AsString;

                AccountList.Add(account);
            }

            return AccountList;
        }
    }
}