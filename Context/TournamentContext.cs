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
    public class TournamentContext
    {

    private readonly IMongoDatabase _database = null;

        public TournamentContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Tournament> Tournaments
        {
            get
            {
                return _database.GetCollection<Tournament>("Tournament");
            }
        }
    }
}