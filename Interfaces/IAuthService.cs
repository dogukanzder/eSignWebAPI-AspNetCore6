//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Models;

namespace eSignAPI.Interfaces;

public interface IAuthService
{
    public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
}
