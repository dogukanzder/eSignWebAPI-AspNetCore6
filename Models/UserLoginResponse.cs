//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

namespace eSignAPI.Models;

public class UserLoginResponse
{
    public bool AuthenticateResult { get; set; }
    public string AuthToken { get; set; } = String.Empty;
    public DateTime AccessTokenExpireDate { get; set; }
}
