using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels.Oficer;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces
{
    public interface IOficerRepository : IRepository<Oficer, Guid>
    {
        Task<IEnumerable<Oficer>> GetLecturalNames(CancellationToken cancellationToken = default);
        Task<IEnumerable<Oficer>> GetFilteredOficer(Guid rankId, Guid positionId, Guid unitId, CancellationToken cancellationToken = default);
    }
}
