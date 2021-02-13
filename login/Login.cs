using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace login
{
    public class Login
    {
        public static Boolean SignIn(AccountModel User)
        {
            if (MongoConnection.GetInDB(User).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean Register(AccountModel NewUser)
        {
            if (MongoConnection.GetInDB(NewUser).Any())
            {
                return false;
            }
            else
            {
                MongoConnection.InsertToDB(NewUser);
                return true;
            }
        }
    }
}
