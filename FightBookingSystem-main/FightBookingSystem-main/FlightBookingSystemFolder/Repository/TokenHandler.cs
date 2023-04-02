using FlightBookingSystemFolder.Models;
namespace FlightBookingSystemFolder.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration _configuration;
    public  TokenHandler(IConfiguration configuration)
    {
        this._configuration=configuration;
    }
    public string CreateTokenAsync(Registration reg)
    {
         

            var claims= new Claim[]{
                new Claim(ClaimTypes.Name,reg.FullName),
                new Claim(ClaimTypes.NameIdentifier,reg.Email.ToString())
        
            };
             var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials= new SigningCredentials(
                key,SecurityAlgorithms.HmacSha256);
            
           var token=new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires:DateTime.Now.AddDays(1),
            signingCredentials:signingCredentials
           );
           var jwtTokenhandler = new JwtSecurityTokenHandler();

            return jwtTokenhandler.WriteToken(token);
        }
    }

