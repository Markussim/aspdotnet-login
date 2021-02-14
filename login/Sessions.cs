using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace login
{
    public class Sessions
    {
        private static List<String> LoggedInUsers = new List<string>();

        public static void AddUser(String ID)
        {
            LoggedInUsers.Add(ID);
        }

        public static bool CheckIfLoggedIn(String ID)
        {
            return LoggedInUsers.Contains(ID);
        }
    }
}
