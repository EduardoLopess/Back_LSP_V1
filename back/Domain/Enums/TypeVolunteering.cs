using System.ComponentModel;

namespace Domain.Enums
{
    public enum TypeVolunteering
    {
        [Description("Ambiental")]
        Environmental, // ambiental
        [Description("Educacional")]
        Educational, // educacional
        [Description("Assistência Médica")]
        HealthCare, // Assistencia medica
        [Description("Bem estar animal")]
        AnimalWelfare, // Bem estar animal
        [Description("Desenvolvimento comunitário")]
        CommunityDevelopment, //Desenvolvimento comunitário
        [Description("Resposta de emergência")]
        EmergencyResponse, //Resposta de emergência
        [Description("Remoto")]
        Remote,
        [Description("Presencial")]
        OnSite // Presencial
    }

   
}