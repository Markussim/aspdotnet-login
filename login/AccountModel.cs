using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace login
{
    public class AccountModel
    {
        public string Name { get; set; }
        public string Pass { get; set; }

        private BsonDocument cacheDoc;

        public BsonDocument ToBson()
        {
            if (cacheDoc == null)
            {
                cacheDoc = new BsonDocument { { "Name", Name }, { "Pass", Pass } };
            }

            return cacheDoc; 
        }
    }
}