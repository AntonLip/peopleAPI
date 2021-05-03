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
    public class CadetRepository : BaseRepository<Cadet>, ICadetRepository
    {
        public CadetRepository(IOptions<MongoDBSettings> mongoDbSettings)
            :base(mongoDbSettings)
        {
                
        }

        public async Task<IEnumerable<Cadet>> GetFilteredOficer(Guid rankId, Guid positionId, Guid unitId, CancellationToken cancellationToken)
        {
            FilterDefinition<Cadet> filter =
                   Builders<Cadet>.Filter.Eq((x => x.IsDeleted), false);

            if (rankId != Guid.Empty)
            {
                filter = filter & Builders<Cadet>.Filter.Eq((x => x.MilitaryRank), rankId);
            }

            if (positionId != Guid.Empty)
            {
                filter = filter & Builders<Cadet>.Filter.Eq((x => x.Position), positionId);
            }
            if (unitId != Guid.Empty)
            {
                filter = filter & Builders<Cadet>.Filter.Eq((x => x.Unit), unitId);
            }
            return await GetCollection().Find(filter).ToListAsync(cancellationToken);
        }
    }
}
