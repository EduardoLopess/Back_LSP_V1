using Domain.Enums;

namespace Domain.Entities
{
    public class Volunteering
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public TypeVolunteering TypeVolunteering { get; set; }
        public string Contact { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public List<string> Responsibilities { get; set; }
        public List<string> Benefits { get; set; }

        public int UserId { get; set; }
        public Address Address { get; set; }
    }
}