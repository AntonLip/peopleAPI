using AutoMapper;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Cadet;
using PeopleAPI.Models.Interfaces;
using PeopleAPI.Models.Interfaces.Repository;
using System;

namespace PeopleAPI.Models.DTOResolver
{
    class MilitaryRankResolver<TModel> : IValueResolver<TModel, PersonInfoDto, string>, IValueResolver<AddOficerDto, TModel, Guid>, IValueResolver<AddCadetDto, TModel, Guid>
        where TModel : IMilitary
    {

        private readonly IMilitaryRankRepository _militaryRepository;

        public MilitaryRankResolver(IMilitaryRankRepository militaryRepository)
        {
            _militaryRepository = militaryRepository;
        }

        public string Resolve(TModel source, PersonInfoDto destination, string destMember, ResolutionContext context)
        {
            try
            {
                return _militaryRepository.GetByIdAsync(source.MilitaryRank).GetAwaiter().GetResult().Name;

            }
            catch
            {
                return string.Empty;
            }
        }

        public Guid Resolve(AddOficerDto source, TModel destination, Guid destMember, ResolutionContext context)
        {
            try
            {
                return _militaryRepository.GetIdByName(source.MilitaryRank).GetAwaiter().GetResult();

            }
            catch
            {
                return Guid.Empty;
            }
        }

        public Guid Resolve(AddCadetDto source, TModel destination, Guid destMember, ResolutionContext context)
        {
            try
            {
                return _militaryRepository.GetIdByName(source.MilitaryRank).GetAwaiter().GetResult();

            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
