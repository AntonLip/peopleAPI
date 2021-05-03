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
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(IOptions<MongoDBSettings> mongoDbSettings)
           : base(mongoDbSettings)
        {

        }

        public async Task<IEnumerable<Position>> GetByStatusAsync(bool isOficer, CancellationToken cancellationToken)
        {
            return await GetCollection().Find(Builders<Position>.Filter.Eq(new ExpressionFieldDefinition<Position, bool>(x => x.IsOficer), isOficer)).ToListAsync();
        }

        public async Task<Guid> GetIdByName(string name, CancellationToken cancellationToken = default)
        {
            var result = await GetCollection().Find(Builders<Position>.Filter.Eq(x => x.name, name)).FirstAsync(cancellationToken);
            return result.Id;
        }
    }
}
