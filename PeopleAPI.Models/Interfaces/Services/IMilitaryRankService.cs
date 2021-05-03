using PeopleAPI.Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces.Services
{
    public interface IMilitaryRankService
    {
        Task<MilitaryRankDto> AddAsync(AddMilitaryRankDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<MilitaryRankDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<MilitaryRankDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<MilitaryRankDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<MilitaryRankDto>> GetByStatusAsync(bool isOficer, CancellationToken cancellationToken = default);

    }
}
