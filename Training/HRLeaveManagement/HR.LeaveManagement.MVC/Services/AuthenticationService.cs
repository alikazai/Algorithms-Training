using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using IAuthenticationService = HR.LeaveManagement.MVC.Contracts.IAuthenticationService;

namespace HR.LeaveManagement.MVC.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JwtSecurityTokenHandler _tokenHandler; 
    public AuthenticationService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor) : base(client, localStorage)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenHandler = new JwtSecurityTokenHandler();
    }

    public async Task<bool> Authenticae(string email, string password)
    {
        try
        {
            AuthRequest authRequest = new() { Email = email, Password = password};
            var authResponse = await Client.LoginAsync(authRequest);

            if (authResponse.Token != String.Empty)
            {
                // Get claims from token and build auth user object
                var tokenContent = _tokenHandler.ReadJwtToken(authResponse.Token);
                var claims = ParseClaims(tokenContent);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme));
                var login = _httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, user);
                LocalStorage.SetStorageValue("token", authResponse.Token);

                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }


    public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new()
            {FirstName = firstName, LastName = lastName, UserName = userName, Email = email, Password = password};

        var response = await Client.RegisterAsync(registrationRequest);

        if (!string.IsNullOrEmpty(response.UserId))
        {
            await Authenticae(email, password);
            return true;
        }

        return false;
    }

    public async Task Logout()
    {
        LocalStorage.ClearStorage(new List<string>(){"token"});
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
    private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
    {
        var claims = tokenContent.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
        return claims;
    }
}