namespace Domain.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Neighborhood  { get; set; } 
        public string Complement { get; set; } 
        public int ZipCode { get; set; }
        public string City { get; set; }
    }
}