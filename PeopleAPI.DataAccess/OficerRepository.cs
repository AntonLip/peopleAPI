using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels.Oficer;
using PeopleAPI.Models.Interfaces;
using PeopleAPI.Models.SettingsClass;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.DataAccess
{
    public class OficerRepository : BaseRepository<Oficer>, IOficerRepository
    {
        public OficerRepository(IOptions<MongoDBSettings> mongoDbSettings)
           : base(mongoDbSettings)
        {

        }

       

        public async Task<IEnumerable<Oficer>> GetFilteredOficer(Guid rankId, Guid positionId, Guid unitId, CancellationToken cancellationToken = default)
        {
            FilterDefinition<Oficer> filter =
                  Builders<Oficer>.Filter.Eq((x => x.IsDeleted), false);

            if (rankId != Guid.Empty)
            {
                filter = filter & Builders<Oficer>.Filter.Eq((x => x.MilitaryRank), rankId);
            }

            if (positionId != Guid.Empty)
            {
                filter = filter & Builders<Oficer>.Filter.Eq((x => x.Position), positionId);
            }
            if (unitId != Guid.Empty)
            {
                filter = filter & Builders<Oficer>.Filter.Eq((x => x.Unit), unitId);
            }
            return await GetCollection().Find(filter).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Oficer>> GetLecturalNames(CancellationToken cancellationToken = default)
        {
            return await GetCollection().Find(Builders<Oficer>.Filter.Eq(x => x.IsLectural, true)).ToListAsync();
        }
    }
}
