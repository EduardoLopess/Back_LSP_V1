using Domain.Enums;

namespace Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
        public Gender Gender { get; set; }
        public string BirthdateString { get; set; }
        public IList<AddressDTO> AddressDTOs { get; set; }
    }
}