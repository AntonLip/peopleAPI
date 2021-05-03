using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.Interfaces;
using PeopleAPI.Models.SettingsClass;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.DataAccess
{
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(IOptions<MongoDBSettings> mongoDbSettings)
            : base(mongoDbSettings)
        {

        }

        public async Task<Guid> GetIdByName(string name, CancellationToken cancellationToken = default)
        {
            return GetCollection().Find(Builders<Unit>.Filter.Eq(new ExpressionFieldDefinition<Unit, string>(x => x.name), name)).First().Id; 
        }

        public async Task<IEnumerable<Unit>> GetUnitByStatus(bool IsOficer, CancellationToken cancellationToken = default)
        {
            return await GetCollection().Find(Builders<Unit>.Filter.Eq(new ExpressionFieldDefinition<Unit, bool>(x => x.IsOficer), IsOficer)).ToListAsync();
        }
    }
}
