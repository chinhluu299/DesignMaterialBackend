using System.Security.Claims;
using DesignMaterialBackend.Data;
using DesignMaterialBackend.Repository.UserRepo;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

public class AuthService : IAuthService
{
    public readonly SignInManager<User> _signInManager;
    public readonly IJwtService _jwtService;
    public readonly IUserRepository _userRepository;
    public AuthService(SignInManager<User> signInManager, IJwtService jwtService, IUserRepository userRepository)
    {
        _signInManager = signInManager;
        _jwtService = jwtService;
        _userRepository = userRepository;
    }
    public async Task<string> CreateConfirmCode(Guid userId)
    {
        return "NotFound";
    }

    public async Task<string> RefreshToken(Guid userId, string refreshToken)
    {
        throw new NotImplementedException();
    }

    public async Task<int> ResetPassword(Guid userId, string confirmCode, string newPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<object> SignIn(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SignOut(Guid userId, string refreshToken)
    {
        throw new NotImplementedException();
    }

    public async Task<string> SignUp(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<ClaimsPrincipal> Verify(string token)
    {
        throw new NotImplementedException();
    }
}