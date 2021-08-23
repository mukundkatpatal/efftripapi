using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using rest.Model;

namespace rest.Repository.Interface
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetAllTournament();
        Task<Tournament> GetTournament(string id);
        Task AddTournament(Tournament item);
        Task<DeleteResult> RemoveTournament(string id);
        Task<ReplaceOneResult> UpdateTournament(string id, Tournament tournament);
        Task<ReplaceOneResult> UpdateTournamentDocument(string id, Tournament tournament);
        Task<DeleteResult> RemoveAllTournament();
    }
}