using Domain.Enums;

namespace Domain.ViewModel
{
    public class VolunteeringViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TypeVolunteering TypeVolunteering { get; set; }
        public List<string> Responsibilities { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public string About { get; set; }
        public string Contact { get; set; }
        public List<string> Benefits { get; set; }
        public AddressViewModel AddressViewModels { get; set; }
    }
}