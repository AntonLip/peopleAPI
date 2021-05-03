using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces
{
    public interface IUnitServices
    {
        Task<UnitDto> AddAsync(AddUnitDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<UnitDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UnitDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<UnitDto> UpdateAsync(Guid id, UnitDto obj, CancellationToken cancellationToken = default);
        Task<UnitDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<UnitDto>> GetUnitByStatus(bool isOficer, CancellationToken cancellationToken = default);
    }
}
