using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FamilyTree.Domain.Accounts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FamilyTree.BusinessLogic.Services;

public class JwtService(IOptions<JwtSettings> options)
{
    public string GenerateToken(Account account)
    {
        var claims = new List<Claim>
        {
            new Claim("Id", account.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Nickname, account.Login)
        };
        
        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(options.Value.Expires),
            claims: claims,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}