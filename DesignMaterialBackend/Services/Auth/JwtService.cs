using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtService : IJwtService
{
  private readonly IConfiguration _configuration;
  public JwtService(IConfiguration configuration){
    _configuration = configuration;
  }

  public string Generate(Claim[] claims){
    var key = Encoding.ASCII.GetBytes(_configuration["Token:Key"]);
    string audience = _configuration["Token:Audience"];
    string issuer = _configuration["Token:Issuer"];

    //config header
    var symmetricSecurityKey = new SymmetricSecurityKey(key);
    var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
    var headers = new JwtHeader(credentials);

    //config payload
    var payload = new JwtPayload(issuer,audience,claims,null,DateTime.Now.AddHours(Constants.TOKEN_LIFE_TIME));
    
    var securityToken = new JwtSecurityToken(headers,payload);
    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }

  public ClaimsPrincipal Verify(string jwt){
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["Token:Key"]);
    string audience = _configuration["Token:Audience"];
    string issuer = _configuration["Token:Issuer"];

    ClaimsPrincipal claims = tokenHandler.ValidateToken(jwt, new TokenValidationParameters(){
      IssuerSigningKey = new SymmetricSecurityKey(key),
      ValidIssuer = issuer,
      ValidAudience = audience,
      ValidateLifetime = true,
      ValidateIssuer = true,
      ValidateAudience = true,
    }, out SecurityToken validatedToken);

    return claims;
  }

  public string GenerateRefreshToken(){
    return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
  }

  public ClaimsPrincipal GetPrincipalFromExpiredToken(string jwt){
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["Token:Key"]);
    string audience = _configuration["Token:Audience"];
    string issuer = _configuration["Token:Issuer"];

    ClaimsPrincipal claims = tokenHandler.ValidateToken(jwt, new TokenValidationParameters()
    {
      IssuerSigningKey = new SymmetricSecurityKey(key),
      ValidIssuer = issuer,
      ValidAudience = audience,
      ValidateLifetime = false,
      ValidateIssuer = true,
      ValidateAudience = true,
    }, out SecurityToken validatedToken);

    return claims;
  }
}