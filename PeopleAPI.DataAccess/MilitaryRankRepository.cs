using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.Interfaces.Repository;
using PeopleAPI.Models.SettingsClass;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.DataAccess
{
    public class MilitaryRankRepository : BaseRepository<MilitaryRank>, IMilitaryRankRepository
    {
        public MilitaryRankRepository(IOptions<MongoDBSettings> mongoDbSettings)
           : base(mongoDbSettings)
        {

        }

        public async Task<IEnumerable<MilitaryRank>> GetbySatatus(bool isOficer, CancellationToken cancellationToken = default)
        {
            return await GetCollection().Find(Builders<MilitaryRank>.Filter.Eq(new ExpressionFieldDefinition<MilitaryRank, bool>(x => x.IsOficers), isOficer)).ToListAsync();
        }

        public async Task<Guid> GetIdByName(string militaryRank, CancellationToken cancellationToken = default)
        {
            var result = await GetCollection().Find(Builders<MilitaryRank>.Filter.Eq(x => x.Name, militaryRank)).FirstAsync(cancellationToken);
            return result.Id;
        }
    }
}
