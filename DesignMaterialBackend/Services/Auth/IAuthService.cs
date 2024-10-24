using System.Security.Claims;

public interface IAuthService
{
  Task<object> SignIn(string email, string password);
  Task<string> RefreshToken(Guid userId, string refreshToken);
  Task<string> CreateConfirmCode(Guid userId);
  Task<bool> SignOut(Guid userId, string refreshToken);
  Task<int> ResetPassword(Guid userId, string confirmCode, string newPassword);
  Task<string> SignUp(string email, string password);
  Task<ClaimsPrincipal> Verify(string token);

}