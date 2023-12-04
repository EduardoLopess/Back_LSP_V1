// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Domain.Entities;
// using Domain.Services.InterfacesServices;
// using Microsoft.IdentityModel.Tokens;

// namespace Api.ServicesConfiguration
// {
//     public class TokenServices : ITokenServices
//     {
//         private readonly IConfiguration _configuration;
//         public TokenServices(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }
//         public string GenerateToken(User user)
//         {
//             var handler = new JwtSecurityTokenHandler();

//             var key = Encoding.ASCII.GetBytes
//             (
//                 _configuration.GetSection("Jwt:Key").Value
//             );

//             var credentials = new SigningCredentials
//             ( 
//                 new SymmetricSecurityKey(key),
//                 SecurityAlgorithms.EcdsaSha256Signature
//             );

//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 SigningCredentials = credentials,
//                 Expires = DateTime.UtcNow.AddHours(5)
//             };

//             var token = handler.CreateToken(tokenDescriptor);
//             return handler.WriteToken(token);
//         }

//     }

//     private static ClaimsIdentity GenerateClaims(User user)
//     {
//         var ci = new ClaimsIdentity();
//         ci.AddClaim(new Claim(ClaimTypes.Role, user.p));
//         foreach (var role in user.ProfileAcess)
//         {
            
//         }
            
//         return ci;
//     }

// }