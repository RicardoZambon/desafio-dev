using ByCoders.Importer.WebApi.Exceptions;
using ByCoders.Importer.WebApi.Models;
using ByCoders.Importer.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ByCoders.Importer.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        /// <summary>
        /// Checks a username and password to grant access to the API.
        /// </summary>
        /// <param name="model">Username and password to authenticate.</param>
        /// <returns>The JWT Token and Refresh Token.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /SignIn
        ///     {
        ///         "Username": "ricardo.zambon",
        ///         "Password": "zambon"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Sucessfully authenticated.</response>
        /// <response code="401">Invalid username or password.</response>
        /// <response code="400">Internal server issue.</response>
        [HttpPost, Route("[action]"), AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            try
            {
                return Ok(await authenticationService.SignInAsync(model));
            }
            catch (InvalidAuthenticationException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Refresh the JWT token using a valid Refresh Token.
        /// </summary>
        /// <param name="model">Username and password to authenticate.</param>
        /// <returns>The JWT Token and Refresh Token.</returns>
        /// <response code="200">Sucessfully refreshed the token.</response>
        /// <response code="401">Invalid Refresh Token or Refresh Token expired.</response>
        /// <response code="400">Internal server issue.</response>
        [HttpPost, Route("[action]"), AllowAnonymous]
        public async Task<IActionResult> RefreshToken(RefreshTokenModel model)
        {
            try
            {
                return Ok(await authenticationService.RefreshTokenAsync(model));
            }
            catch (InvalidRefreshTokenException)
            {
                return Unauthorized();
            }
            catch (RefreshTokenNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("[action]")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthCookie");
            return Ok();
        }
    }
}
