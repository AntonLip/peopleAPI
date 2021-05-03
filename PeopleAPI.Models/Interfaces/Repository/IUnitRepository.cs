using PeopleAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces
{
    public interface IUnitRepository : IRepository<Unit, Guid>
    {
        Task<Guid> GetIdByName(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<Unit>> GetUnitByStatus(bool IsOficer, CancellationToken cancellationToken = default);

    }
}
