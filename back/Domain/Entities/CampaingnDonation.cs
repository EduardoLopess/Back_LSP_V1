using Domain.Enums;

namespace Domain.Entities
{
    public class CampaingnDonation
    {
        public int Id { get; set; }
        public string TitleCampaing { get; set; }
        public string DescriptionCampaingn { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public string Contact { get; set; }
        public string About { get; set; }

        public DonationMaterialType MaterialType { get; set; }
        public PriorityDonation PriorityDonation { get; set; }
        public Address Address { get; set; }
    }
}