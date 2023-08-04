//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Models;

namespace eSignAPI.Interfaces;

public interface ITokenService
{
    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
}
