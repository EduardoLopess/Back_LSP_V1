using Domain.Enums;

namespace Domain.ViewModel
{
    public class UserViewModel : LoginViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public Gender Gender { get; set; }
        public string BirthdateString { get; set; }
        public IList<AddressViewModel> AddressViewModels { get; set; }
    }
}