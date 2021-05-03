using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces
{
    public interface IPositionServices
    {
        Task<PositionDto> AddAsync(AddPositionDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<PositionDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PositionDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PositionDto> UpdateAsync(Guid id, PositionDto obj, CancellationToken cancellationToken = default);
        Task<PositionDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<PositionDto>> GetPositionByStatus(bool isOficer, CancellationToken cancellationToken = default);
    }
}
