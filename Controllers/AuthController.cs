//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Interfaces;
using eSignAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eSignAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	readonly IAuthService authService;

	public AuthController(IAuthService authService)
	{
		this.authService = authService;
	}

    [HttpPost("LoginUser")]
    [AllowAnonymous]
    public async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
    {
        try
        {
            var result = await authService.LoginUserAsync(request);

            return result;
        }
        catch (Exception)
        {
            return NotFound();
        }

    }
}
