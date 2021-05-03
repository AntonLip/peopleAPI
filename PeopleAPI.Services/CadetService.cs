using AutoMapper;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Cadet;
using PeopleAPI.Models.DTOModels.Oficer;
using PeopleAPI.Models.Interfaces;
using PeopleAPI.Models.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Services
{
    public class CadetService : ICadetService
    {
        private readonly ICadetRepository _cadetRepository;

        private readonly IMilitaryRankRepository _militaryRankRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public CadetService(ICadetRepository cadetRepository,
                           IMilitaryRankRepository militaryRankRepository,
                            IPositionRepository positionRepository,
                            IUnitRepository unitRepository,
                            IMapper mapper)
        {
            _mapper = mapper;
            _cadetRepository = cadetRepository;
            _militaryRankRepository = militaryRankRepository;
            _positionRepository = positionRepository;
            _unitRepository = unitRepository;
        }
        public async Task<PersonInfoDto> AddAsync(AddCadetDto model, CancellationToken cancellationToken = default)
        {
            if(model is null)
            {
                throw new ArgumentNullException();
            }
            var cadet = _mapper.Map<Cadet>(model);
            await _cadetRepository.AddAsync(cadet, cancellationToken);
            return _mapper.Map<PersonInfoDto>(cadet);
        }

        public async Task<IEnumerable<PersonInfoDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var cadets = await _cadetRepository.GetAllAsync(cancellationToken);
            return cadets is null ? throw new ArgumentOutOfRangeException() : _mapper.Map<List<PersonInfoDto>>(cadets);
        }

        public async Task<PersonInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var cadet = await _cadetRepository.GetByIdAsync(id, cancellationToken);
            return cadet is null ? throw new ArgumentOutOfRangeException() : _mapper.Map<PersonInfoDto>(cadet);
        }

        public async Task<IEnumerable<PersonInfoDto>> GetFilteredOficers(PersonFilter filter, CancellationToken cancellationToken = default)
        {
            Guid rankId = Guid.Empty, positionId = Guid.Empty, unitId = Guid.Empty;
            if (!(filter.MilitaryRank is null))
            {
                rankId =  await _militaryRankRepository.GetIdByName(filter.MilitaryRank, cancellationToken);
            }
            if (!(filter.Position is null))
            {
                positionId = await _positionRepository.GetIdByName(filter.Position, cancellationToken);
            }
            if (!(filter.Unit is null))
            {
                unitId = await _unitRepository.GetIdByName(filter.Unit, cancellationToken);
            }
            var result = await _cadetRepository.GetFilteredOficer(rankId, positionId, unitId, cancellationToken);

            return result is null ? throw new ArgumentNullException() : _mapper.Map<List<PersonInfoDto>>(result);
        }

        public async Task<UpdateCadetDto> GetFullInfoByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var cadet = await _cadetRepository.GetByIdAsync(id, cancellationToken);
            return cadet is null ? throw new ArgumentOutOfRangeException() : _mapper.Map<UpdateCadetDto>(cadet);
        }

        public async Task<PersonInfoDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var cadet = await _cadetRepository.GetByIdAsync(id);

            await _cadetRepository.RemoveAsync(id, cancellationToken);

            return cadet is null ? throw new ArgumentOutOfRangeException() : _mapper.Map<PersonInfoDto>(cadet);
        }

        public async Task<PersonInfoDto> UpdateAsync(Guid id, UpdateCadetDto model, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            if (model is null)
            {
                throw new ArgumentNullException();
            }
            var cadet = _mapper.Map<Cadet>(model);

            await _cadetRepository.UpdateAsync(id, cadet, cancellationToken);

            return cadet is null ? throw new ArgumentOutOfRangeException() : _mapper.Map<PersonInfoDto>(cadet);
        }
    }
}
