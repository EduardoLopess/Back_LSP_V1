using System.ComponentModel;

namespace Domain.Enums
{
    public enum PriorityDonation
    {
        [Description("Baixa")]
        lower = 1,
        [Description("Média")]
        medium = 2,
        [Description("Alta")]
        high = 3
    }
}