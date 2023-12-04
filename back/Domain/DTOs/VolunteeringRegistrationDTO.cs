namespace Domain.DTOs
{
    public class VolunteeringRegistrationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Id do usuário
        public int VolunteeringId { get; set; } // Id do voluntariado
        public DateTime RegistrationDate { get; set; }
    }
}