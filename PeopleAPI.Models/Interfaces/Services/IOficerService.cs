using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Oficer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Models.Interfaces
{
    public interface IOficerService 
    {
        Task<PersonInfoDto> AddAsync(AddOficerDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<PersonInfoDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PersonInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<UpdateOficerDto> GetFullInfoByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PersonInfoDto> UpdateAsync(Guid id, UpdateOficerDto obj, CancellationToken cancellationToken = default);
        Task<PersonInfoDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<LecturalNames>> GetLecturalNames(CancellationToken cancellationToken = default);
        Task<IEnumerable<PersonInfoDto>> GetFilteredOficers(PersonFilter personFilter, CancellationToken cancellationToken = default);
    }
}
