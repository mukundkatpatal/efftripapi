using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TournamentController : Controller
    {
        private readonly IConfiguration _configuration;
        public TournamentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));

            var dbList = dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpGet("getById")]
        public JsonResult Get(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));
            var filter = Builders<Tournament>.Filter.Eq("TournamentId", id);

            var dbList = dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").Find(filter).ToList();

            return new JsonResult(dbList);
        }
        [HttpPost]
        
        public JsonResult Post([FromBody] Tournament tournament)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));

                    int LastTournamentId = dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").AsQueryable().Count();
                    tournament.TournamentId = LastTournamentId + 1;

                    dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").InsertOne(tournament);

                    return new JsonResult("Added Successfully");

                }
                else
                {

                    return new JsonResult(HttpStatusCode.BadRequest, "Error retriveing Data from Database");

                }


            }
            catch
            {
                return new JsonResult(HttpStatusCode.BadRequest, "Error retriveing Data from Database");
            }
           
        }


        [HttpPut]
        public JsonResult Put([FromBody] Tournament tournament)
        {


            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));

            var filter = Builders<Tournament>.Filter.Eq("TournamentId", tournament.TournamentId);


            var update = Builders<Tournament>.Update.Set("TournamentName", tournament.TournamentName)
                                                     .Set("Place", tournament.Place)
                                                     .Set("StartDate", tournament.StartDate)
                                                     .Set("EndDate", tournament.EndDate)
                                                     .Set("Rounds", tournament.Rounds)
                                                     .Set("Category", tournament.Category)
                                                     .Set("Website", tournament.Website);



            dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").UpdateOne(filter, update);


            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));

            var filter = Builders<Tournament>.Filter.Eq("TournamentId", id);


            dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }


    }
}
