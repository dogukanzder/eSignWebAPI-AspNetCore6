//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Interfaces;
using eSignAPI.Models;
using MongoDB.Driver;

namespace eSignAPI.Services;

public class AuthService : IAuthService
{
    readonly ITokenService tokenService;
    private readonly IMongoCollection<User> _users;


    public AuthService(ITokenService tokenService, IUsersLoginDatabaseSettings settings, IMongoClient mongoClient)
    {
        this.tokenService = tokenService;

        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _users = database.GetCollection<User>(settings.UserCollectionName);
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
    {
        UserLoginResponse response = new();

        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentNullException(nameof(request));
        }

        User? user;
        try
        {
            user = _users.Find(user => user.Email == request.Email).FirstOrDefault();
        }
        catch (Exception)
        {
            user = null;
        }

        var textBytes = System.Text.Encoding.UTF8.GetBytes(request.Password);

        if (user != null && user.Password == System.Convert.ToBase64String(textBytes))
        {
            var generatedTokenInformation = await tokenService.GenerateToken(new GenerateTokenRequest { Email = request.Email });

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;           
        }

        return response;
    }
}
