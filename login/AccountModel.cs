using System;
using System.Collections.Generic;


namespace login
{
     public class AccountModel
    {
        public string Name { get; }
        public string Pass { get; }

        public AccountModel(String NameIn, String PassIn) {
            Name = NameIn;
            Pass = PassIn;
        }
    }
}