using AutoMapper;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Cadet;
using PeopleAPI.Models.Interfaces;
using System;

namespace PeopleAPI.Models.DTOResolver
{
    public class PositionResolver<TModel> : IValueResolver<TModel, PersonInfoDto, string>  , IValueResolver<AddOficerDto , TModel, Guid>, IValueResolver<AddCadetDto, TModel, Guid>
        where TModel : BaseMan
    {

        private readonly IPositionRepository _postionRepository;

        public PositionResolver(IPositionRepository postionRepository)
        {
            _postionRepository = postionRepository;
        }
        public string Resolve(TModel source, PersonInfoDto destination, string destMember, ResolutionContext context)
        {
            try
            {
                return _postionRepository.GetByIdAsync(source.Position).GetAwaiter().GetResult().name;

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
                return _postionRepository.GetIdByName(source.Position).GetAwaiter().GetResult();

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
                return _postionRepository.GetIdByName(source.Position).GetAwaiter().GetResult();

            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
