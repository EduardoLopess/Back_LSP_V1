using Domain.Enums;

namespace Domain.DTOs
{
    public class CampaingnDonationDTO
    {
        public int Id { get; set; }
        public string TitleCampaing { get; set; }
        public string DescriptionCampaingn { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
         public string Contact { get; set; }
        public DonationMaterialType MaterialType { get; set; }
        public string TypeMaterialTypeDescription { get; set; }
        public string PriorityDonationDescription { get; set; }
        public string About { get; set; }

        public PriorityDonation PriorityDonation { get; set; }
        public AddressDTO AddressDTO { get; set; }

        // Propriedades adicionadas para dia, mês e ano
        public int DayStart { get; set; }
        public int MonthStart { get; set; }
        public int YearStart { get; set; }

        public int DayFinish { get; set; }
        public int MonthFinish { get; set; }
        public int YearFinish { get; set; }
    }
}
