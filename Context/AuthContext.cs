using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rest.Model;

namespace rest.Context
{
    public class AuthContext{

    private readonly IMongoDatabase _database = null;

        public AuthContext(IOptions<Settings> settings)

        {
            var client = new MongoClient(settings.Value.ConnectionString);
             
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("User");
            }
        }
    }
}