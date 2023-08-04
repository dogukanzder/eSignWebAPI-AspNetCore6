//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

namespace eSignAPI.Models;

public class UserLoginRequest
{
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}
