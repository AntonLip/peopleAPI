using AutoMapper;
using PeopleAPI.Models.DBModels;
using PeopleAPI.Models.DTOModels;
using PeopleAPI.Models.DTOModels.Cadet;
using PeopleAPI.Models.DTOModels.Oficer;
using PeopleAPI.Models.DTOResolver;
using System;

namespace PeopleAPI.Models.SettingsClass
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddUnitDto, Unit>().AfterMap((src, dest) => dest.Id = Guid.NewGuid());
            CreateMap<AddMilitaryRankDto, MilitaryRank>().AfterMap((src, dest) => dest.Id = Guid.NewGuid());
            CreateMap<AddPositionDto, Position>().AfterMap((src, dest) => dest.Id = Guid.NewGuid());
            
            CreateMap<PositionDto, Position>().ReverseMap();
            CreateMap<UnitDto, Unit>().ReverseMap();

            CreateMap<Oficer, LecturalNames>().AfterMap((src, dest) =>
            {
                dest.Name = src.LastName;
                dest.Id = src.Id;
            }).ReverseMap();

            CreateMap<MilitaryRankDto, MilitaryRank>().ReverseMap();

            CreateMap<Oficer, PersonInfoDto>()
                .ForMember(dest => dest.Position,
                opt => opt.MapFrom<PositionResolver<Oficer>>())
                .ForMember(dest => dest.Unit,
                opt => opt.MapFrom<UnitResolver<Oficer>>())
                .ForMember(dest => dest.MilitaryRank,
                opt => opt.MapFrom<MilitaryRankResolver<Oficer>>())
                .ReverseMap();

            CreateMap<AddOficerDto, Oficer>()
                .ForMember(dest => dest.Position,
                    opt => opt.MapFrom<PositionResolver<Oficer>>())
                .ForMember(dest => dest.Unit,
                    opt => opt.MapFrom<UnitResolver<Oficer>>())
                .ForMember(dest => dest.MilitaryRank,
                opt => opt.MapFrom<MilitaryRankResolver<Oficer>>())
                .ReverseMap();

            CreateMap<Cadet, PersonInfoDto>()
                .ForMember(dest => dest.Position,
                opt => opt.MapFrom<PositionResolver<Cadet>>())
                .ForMember(dest => dest.Unit,
                opt => opt.MapFrom<UnitResolver<Cadet>>())
                .ForMember(dest => dest.MilitaryRank,
                opt => opt.MapFrom<MilitaryRankResolver<Cadet>>())
                .ReverseMap();

            CreateMap<AddCadetDto, Cadet>()
                .ForMember(dest => dest.Position,
                    opt => opt.MapFrom<PositionResolver<Cadet>>())
                .ForMember(dest => dest.Unit,
                    opt => opt.MapFrom<UnitResolver<Cadet>>())
                 .ForMember(dest => dest.MilitaryRank,
                opt => opt.MapFrom<MilitaryRankResolver<Cadet>>())
                .ReverseMap();
        }
    }
}
