//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

namespace eSignAPI.Models;

public class GenerateTokenResponse
{
    public string Token { get; set; } = String.Empty;
    public DateTime TokenExpireDate { get; set; }
}
