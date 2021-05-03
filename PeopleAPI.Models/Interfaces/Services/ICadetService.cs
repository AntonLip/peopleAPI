using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Cadet;
using PeopleAPI.Models.DTOModels.Oficer;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces
{
    public interface ICadetService
    {
        Task<PersonInfoDto> AddAsync(AddCadetDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<PersonInfoDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PersonInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<UpdateCadetDto> GetFullInfoByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PersonInfoDto> UpdateAsync(Guid id, UpdateCadetDto obj, CancellationToken cancellationToken = default);
        Task<PersonInfoDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<PersonInfoDto>> GetFilteredOficers(PersonFilter filter, CancellationToken cancellationToken = default);
    }
}
