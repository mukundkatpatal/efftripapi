using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using rest.Infra;
using rest.Model;
using rest.Repository.Interface;

namespace rest.Controllers
{
    [Authorize(Policy = "Member")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository _TournamentRepository;

        public TournamentController(ITournamentRepository TournamentRepository)
        {
            _TournamentRepository = TournamentRepository;
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<Tournament>> Get()
        {
            return GetTournamentInternal();
        }

        private async Task<IEnumerable<Tournament>> GetTournamentInternal()
        {
            return await _TournamentRepository.GetAllTournament();
        }

        // GET api/Tournaments/5
        [HttpGet("{id}")]
        public Task<Tournament> Get(string id)
        {
            return GetTournamentByIdInternal(id);
        }

        private async Task<Tournament> GetTournamentByIdInternal(string id)
        {
            return await _TournamentRepository.GetTournament(id) ?? new Tournament();
        }

        // POST api/Tournament
        [HttpPost]
        public void Post([FromBody] Tournament tournament)
        {
            _TournamentRepository.AddTournament(new Tournament() 
                {   Id = ObjectId.GenerateNewId().ToString(),
                    Name = tournament.Name, 
                    Place = tournament.Place,
                    StartDate=tournament.StartDate,
                    EndDate=tournament.EndDate,
                    Rounds=tournament.Rounds,
                    Category=tournament.Category,
                    URL=tournament.URL

                   
                });
        }

        // PUT api/Tournaments/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Tournament tournament)
        {
            _TournamentRepository.UpdateTournamentDocument(id, tournament);
        }

        // DELETE api/Tournaments/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _TournamentRepository.RemoveTournament(id);
        }
    }
}
