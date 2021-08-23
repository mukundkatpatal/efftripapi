using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using rest.Context;
using rest.Model;

namespace rest.Repository.Interface
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TournamentContext _context = null;

        public TournamentRepository()
        {
        }

        public TournamentRepository(IOptions<Settings> settings)
        {
            _context = new TournamentContext(settings);
        }

        public async Task AddTournament(Tournament item)
        {
            await _context.Tournaments.InsertOneAsync(item);
        }

        public async Task<IEnumerable<Tournament>> GetAllTournament()
        {
            return await _context.Tournaments.Find(_ => true).ToListAsync();
        }

        public async Task<Tournament> GetTournament(string id)
        {
            var filter = Builders<Tournament>.Filter.Eq("Id", id);
            return await _context.Tournaments
                                .Find(filter)
                                .FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveAllTournament()
        {
            return await _context.Tournaments.DeleteManyAsync(new BsonDocument());
        }

        public async Task<DeleteResult> RemoveTournament(string id)
        {
            return await _context.Tournaments.DeleteOneAsync(
                        Builders<Tournament>.Filter.Eq("Id", id));
        }

        public async Task<ReplaceOneResult> UpdateTournament(string id, Tournament item)
        {
            try
            {
                return await _context.Tournaments
                            .ReplaceOneAsync(n => n.Id.Equals(id)
                                            , item
                                            , new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<ReplaceOneResult> UpdateTournamentDocument(string id, Tournament tournament)
        {
            var item = await GetTournament(id) ?? new Tournament();
            item.Name = tournament.Name;
            item.Place = tournament.Place;
            item.StartDate = tournament.StartDate;
            item.EndDate = tournament.EndDate;
            item.Rounds = tournament.Rounds;
            item.Category = tournament.Category;
            item.URL = tournament.URL;



            return await UpdateTournamentDocument(id, item);
        }
    }
}