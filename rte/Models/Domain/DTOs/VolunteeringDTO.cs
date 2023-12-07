using Domain.Enums;

namespace Domain.DTOs
{
    public class VolunteeringDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TypeVolunteering TypeVolunteering { get; set; }
        public string TypeVolunteeringDescription { get; set; }
        public string Contact { get; set; }
        public string About { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public List<string> Responsibilities { get; set; }
        public List<string> Benefits { get; set; }
        public int UserId { get; set; }
        public AddressDTO AddressDTOs { get; set; }

          // Propriedades adicionadas para dia, mês e ano
        public int DayStart { get; set; }
        public int MonthStart { get; set; }
        public int YearStart { get; set; }

        public int DayFinish { get; set; }
        public int MonthFinish { get; set; }
        public int YearFinish { get; set; }

    }
}