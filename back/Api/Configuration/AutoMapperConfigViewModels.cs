using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;

namespace Api.Configuration
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.BirthdateString, opt => opt.MapFrom(src => src.BirthdateString))                
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.ProfileAcess, opt => opt.MapFrom(src => src.ProfileAcess))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.AddressViewModels));

            CreateMap<AddressViewModel, Address>();

            CreateMap<VolunteeringViewModel, Volunteering>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressViewModels));

            CreateMap<CampaingnDonationViewModel, CampaingnDonation>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressViewModel));
        }
    }
}