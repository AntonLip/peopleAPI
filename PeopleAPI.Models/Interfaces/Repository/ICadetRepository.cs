using PeopleAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces
{
    public interface ICadetRepository : IRepository<Cadet, Guid>
    {
        Task<IEnumerable<Cadet>> GetFilteredOficer(Guid rankId, Guid positionId, Guid unitId, CancellationToken cancellationToken);
    }
}
