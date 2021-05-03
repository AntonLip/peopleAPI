using AutoMapper;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Services
{
    public class UnitService : IUnitServices
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UnitService(IUnitRepository unitRepository,
                         IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }
        public async Task<UnitDto> AddAsync(AddUnitDto obj, CancellationToken cancellationToken = default)
        {
            if (obj is null)
            {
                throw new ArgumentNullException();
            }
            var unit = _mapper.Map<Unit>(obj);
            await _unitRepository.AddAsync(unit);
            return _mapper.Map<UnitDto>(unit);

        }

        public async Task<IEnumerable<UnitDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _unitRepository.GetAllAsync();
            return result is null ? throw new ArgumentException() : _mapper.Map<IEnumerable<UnitDto>>(result);
        }

        public async Task<UnitDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var unit = await _unitRepository.GetByIdAsync(id);
            return unit is null ? throw new ArgumentException() : _mapper.Map<UnitDto>(unit);
        }

        public async Task<IEnumerable<UnitDto>> GetUnitByStatus(bool isOficer, CancellationToken cancellationToken = default)
        {
            var units = await _unitRepository.GetUnitByStatus(isOficer);
            return units is null ? throw new ArgumentNullException() : _mapper.Map<List<UnitDto>>(units);
        }

        public async Task<UnitDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var unit = await _unitRepository.RemoveAsync(id);
            return unit is null ? throw new ArgumentException() : _mapper.Map<UnitDto>(unit);
        }

        public async Task<UnitDto> UpdateAsync(Guid id, UnitDto obj, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var unit = _mapper.Map<Unit>(obj);
            await _unitRepository.UpdateAsync(id, unit, cancellationToken);
            return unit is null ? throw new ArgumentException() : _mapper.Map<UnitDto>(unit);
        }
    }
}
