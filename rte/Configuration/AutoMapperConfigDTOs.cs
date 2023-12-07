using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FullName, map => map.MapFrom(src => $"{src.Name} {src.Surname}"))
                .ForMember(dest => dest.AddressDTOs, map => map.MapFrom(src => src.Addresses));

            CreateMap<Address, AddressDTO>();

            CreateMap<Volunteering, VolunteeringDTO>()
                .ForMember(dest => dest.TypeVolunteeringDescription, opt =>
                    opt.MapFrom(src => src.TypeVolunteering.GetDescription())
                )
                .ForMember(dest => dest.AddressDTOs, map => map.MapFrom(src => src.Address))
                .ForMember(dest => dest.DayStart, opt => opt.MapFrom(src => src.DateStart.Day))
                .ForMember(dest => dest.MonthStart, opt => opt.MapFrom(src => src.DateStart.Month))
                .ForMember(dest => dest.YearStart, opt => opt.MapFrom(src => src.DateStart.Year))
                .ForMember(dest => dest.DayFinish, opt => opt.MapFrom(src => src.DateFinish.Day))
                .ForMember(dest => dest.MonthFinish, opt => opt.MapFrom(src => src.DateFinish.Month))
                .ForMember(dest => dest.YearFinish, opt => opt.MapFrom(src => src.DateFinish.Year));
               
            CreateMap<VolunteeringRegistration, VolunteeringRegistrationDTO>();

           CreateMap<CampaingnDonation, CampaingnDonationDTO>()
                .ForMember(dest => dest.TypeMaterialTypeDescription, opt =>
                    opt.MapFrom(src => src.MaterialType.GetDescription()))
                .ForMember(dest => dest.PriorityDonationDescription, opt =>
                    opt.MapFrom(src => src.PriorityDonation.GetDescription()))
                .ForMember(dest => dest.AddressDTO, map => map.MapFrom(src => src.Address))
                .ForMember(dest => dest.DayStart, opt => opt.MapFrom(src => src.DateStart.Day))
                .ForMember(dest => dest.MonthStart, opt => opt.MapFrom(src => src.DateStart.Month))
                .ForMember(dest => dest.YearStart, opt => opt.MapFrom(src => src.DateStart.Year))
                .ForMember(dest => dest.DayFinish, opt => opt.MapFrom(src => src.DateFinish.Day))
                .ForMember(dest => dest.MonthFinish, opt => opt.MapFrom(src => src.DateFinish.Month))
                .ForMember(dest => dest.YearFinish, opt => opt.MapFrom(src => src.DateFinish.Year));


                    
            
                
        
        }
    }
}

 

  