using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces.Repository
{
    public interface IMilitaryRankRepository : IRepository<MilitaryRank, Guid>
    {
        Task<IEnumerable<MilitaryRank>> GetbySatatus(bool isOficer, CancellationToken cancellationToken = default);
        Task<Guid> GetIdByName(string militaryRank, CancellationToken cancellationToken = default);
    }
}
