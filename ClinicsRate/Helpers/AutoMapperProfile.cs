using AutoMapper;
using ClinicsRate.Models;
using ClinicsRate.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Clinic, ClinicDto>()
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.DictProvince.Name))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.DictCity.Name));

            CreateMap<ClinicDto, Clinic>()
                .ForMember(dest => dest.ProvinceId, opt => opt.MapFrom(src => src.Province))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.City));

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
