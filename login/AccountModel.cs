using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace login
{
    public class AccountModel
    {
        public string Name { get; set; }
        public string Pass { get; set; }

        public BsonDocument ToBson() {
            return new BsonDocument { { "Name", Name }, { "Pass", Pass } };
        }
    }
}