using System.Security.Claims;

public interface IJwtService
{
  string Generate(Claim[] claims);
  ClaimsPrincipal Verify(string jwt);
  string GenerateRefreshToken();
  ClaimsPrincipal GetPrincipalFromExpiredToken(string jwt);
}