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
    public class PositionService : IPositionServices
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository,
                         IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }
        public async Task<PositionDto> AddAsync(AddPositionDto obj, CancellationToken cancellationToken = default)
        {
            if (obj is null)
            {
                throw new ArgumentNullException();
            }
            var position = _mapper.Map<Position>(obj);
            await _positionRepository.AddAsync(position);
            return _mapper.Map<PositionDto>(position);

        }

        public async Task<IEnumerable<PositionDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _positionRepository.GetAllAsync();
            return result is null ? throw new ArgumentException() : _mapper.Map<IEnumerable<PositionDto>>(result);
        }

        public async Task<PositionDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var position = await _positionRepository.GetByIdAsync(id, cancellationToken);
            return position is null ? throw new ArgumentException() : _mapper.Map<PositionDto>(position);
        }

        public async Task<IEnumerable<PositionDto>> GetPositionByStatus(bool isOficer, CancellationToken cancellationToken = default)
        {
            var position = await _positionRepository.GetByStatusAsync(isOficer, cancellationToken);
            return position is null ? throw new ArgumentException() : _mapper.Map<List<PositionDto>>(position);
        }

        public async Task<PositionDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var position = await _positionRepository.RemoveAsync(id);
            return position is null ? throw new ArgumentException() : _mapper.Map<PositionDto>(position);
        }

        public async Task<PositionDto> UpdateAsync(Guid id, PositionDto obj, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var position = _mapper.Map<Position>(obj);
            await _positionRepository.UpdateAsync(id, position, cancellationToken);
            return position is null ? throw new ArgumentException() : _mapper.Map<PositionDto>(position);
        }
    }
}
