using Domain.Entities;

namespace Domain.Services.InterfacesServices
{
    public interface ITokenServices
    {
        string GenerateToken(User user);
    }
}