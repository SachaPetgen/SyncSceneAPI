using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SyncScene.Domain.Models;

public class TokenService
{
    
    private readonly IConfiguration _configuration;
    
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
        
    public string GenerateToken(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim("id", user.Id.ToString()),
            new Claim("username", user.Username),
            new Claim("email", user.Email),
            new Claim("role", user.Role.ToString())
        };
    
        // Key for signing the token
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        // Signing credentials with the encryption key and algorithm
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        // Generate the token
        JwtSecurityToken token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"], // Issuer of the token (usually your API server)
            _configuration["Jwt:Audience"], // Audience that uses the token (client side)
            claims,
            expires: DateTime.UtcNow.AddMinutes(15), // Token expiration (short-lived access token)
            signingCredentials: creds
        );

        // Return the token as a string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}