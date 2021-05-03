using AutoMapper;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.Interfaces.Repository;
using PeopleAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAPI.Services
{
    public class MilitaryRankService : IMilitaryRankService
    {
        private readonly IMilitaryRankRepository _militaryRankRepository;
        private readonly IMapper _mapper;

        public MilitaryRankService(IMilitaryRankRepository militaryRankRepository, IMapper mapper)
        {
            _mapper = mapper;
            _militaryRankRepository = militaryRankRepository;
        }
        public async Task<MilitaryRankDto> AddAsync(AddMilitaryRankDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
                throw new ArgumentNullException();

            var rank = _mapper.Map<MilitaryRank>(model);

            await _militaryRankRepository.AddAsync(rank);
            return _mapper.Map<MilitaryRankDto>(rank);
        }

        public async Task<IEnumerable<MilitaryRankDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var ranks = await _militaryRankRepository.GetAllAsync();
            return _mapper.Map<List<MilitaryRankDto>>(ranks);
        }

        public  async Task<MilitaryRankDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {

            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var ranks = await _militaryRankRepository.GetByIdAsync(id);
            return _mapper.Map<MilitaryRankDto>(ranks);
        }

        public async Task<IEnumerable<MilitaryRankDto>> GetByStatusAsync(bool isOficer, CancellationToken cancellationToken = default)
        {
            var result = await _militaryRankRepository.GetbySatatus(isOficer, cancellationToken);
            return result is null ? throw new ArgumentNullException() : _mapper.Map<List<MilitaryRankDto>>(result);
        }

        public async Task<MilitaryRankDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var ranks = await _militaryRankRepository.GetByIdAsync(id);
            if (ranks is null)
                throw new ArgumentNullException();
            _militaryRankRepository.RemoveAsync(id);

            return _mapper.Map<MilitaryRankDto>(ranks);
        }
    }
}
