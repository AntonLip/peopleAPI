using PeopleAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces
{
    public interface IPositionRepository: IRepository<Position, Guid>
    {
        Task<Guid> GetIdByName(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<Position>> GetByStatusAsync(bool isOficer, CancellationToken cancellationToken);
    }
}
