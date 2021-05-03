using AutoMapper;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Oficer;
using PeopleAPI.Models.Interfaces;
using PeopleAPI.Models.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Services
{
    public class OficerService : IOficerService
    {
        private readonly IOficerRepository _oficerRepository;
        private readonly IMilitaryRankRepository _militaryRankRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IUnitRepository _unitRepository;


        private readonly IMapper _mapper;

        public OficerService(IOficerRepository oficerRepository,
                            IMilitaryRankRepository militaryRankRepository,
                            IPositionRepository positionRepository,
                            IUnitRepository unitRepository,
                            IMapper mapper)
        {
            _mapper = mapper;
            _oficerRepository = oficerRepository;
            _militaryRankRepository = militaryRankRepository;
            _positionRepository = positionRepository;
            _unitRepository = unitRepository;
        }
        public async Task<PersonInfoDto> AddAsync(AddOficerDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
            {
                throw new ArgumentNullException();
            }
            var oficer = _mapper.Map<Oficer>(model);
            await _oficerRepository.AddAsync(oficer);
            return _mapper.Map<PersonInfoDto>(oficer);
        }

        public async Task<IEnumerable<PersonInfoDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var oficers = await _oficerRepository.GetAllAsync(cancellationToken);
            return oficers is null ? throw new ArgumentException() : _mapper.Map<List<PersonInfoDto>>(oficers);
        }

        public async Task<PersonInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var oficer = await _oficerRepository.GetByIdAsync(id, cancellationToken);
            return oficer is null ? throw new ArgumentException() : _mapper.Map<PersonInfoDto>(oficer);
        }

        public async Task<IEnumerable<PersonInfoDto>> GetFilteredOficers(PersonFilter personFilter, CancellationToken cancellationToken = default)
        {
            var rankId = await _militaryRankRepository.GetIdByName(personFilter.MilitaryRank, cancellationToken);
            var positionId = await _positionRepository.GetIdByName(personFilter.Position, cancellationToken);
            var unitId = await _unitRepository.GetIdByName(personFilter.Unit, cancellationToken);

            var result = await _oficerRepository.GetFilteredOficer(rankId, positionId, unitId, cancellationToken);

            return result is null ? throw new ArgumentNullException() : _mapper.Map<List<PersonInfoDto>>(result);

        }

        public async Task<UpdateOficerDto> GetFullInfoByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var oficer = await _oficerRepository.GetByIdAsync(id, cancellationToken);
            return oficer is null ? throw new ArgumentException() : _mapper.Map<UpdateOficerDto>(oficer);
        }

        public async Task<IEnumerable<LecturalNames>> GetLecturalNames(CancellationToken cancellationToken = default)
        {
            var lecturals =  await _oficerRepository.GetLecturalNames();
            return lecturals is null ? throw new ArgumentNullException() : _mapper.Map<List<LecturalNames>>(lecturals);
        }

        public async Task<PersonInfoDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }
            var oficer = await _oficerRepository.GetByIdAsync(id, cancellationToken);

            await _oficerRepository.RemoveAsync(id, cancellationToken);

            return _mapper.Map<PersonInfoDto>(oficer);
        }

        public async Task<PersonInfoDto> UpdateAsync(Guid id, UpdateOficerDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
            {
                throw new ArgumentNullException();
            }
            var newOficer = _mapper.Map<Oficer>(model);
            await _oficerRepository.UpdateAsync(id, newOficer, cancellationToken);

            return _mapper.Map<PersonInfoDto>(newOficer);
        }
    
    
    
    
    
    
    }
}
