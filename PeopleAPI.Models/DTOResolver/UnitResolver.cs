using AutoMapper;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Cadet;
using PeopleAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.DTOResolver
{
    public class UnitResolver<TModel> : IValueResolver<TModel, PersonInfoDto, string>,  IValueResolver<AddOficerDto, TModel, Guid>, IValueResolver<AddCadetDto, TModel, Guid>
        where TModel : BaseMan
    {

        private readonly IUnitRepository _unitRepository;
        public UnitResolver(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }        

        public string Resolve(TModel source, PersonInfoDto destination, string destMember, ResolutionContext context)
        {
            try
            {
                return _unitRepository.GetByIdAsync(source.Unit).GetAwaiter().GetResult().name;

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
                return _unitRepository.GetIdByName(source.Unit).GetAwaiter().GetResult();

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
                return _unitRepository.GetIdByName(source.Unit).GetAwaiter().GetResult();

            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
