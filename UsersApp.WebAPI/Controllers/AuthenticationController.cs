using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersApp.BLL.Services.Interface;
using UsersApp.DTOs.Request;

namespace UsersApp.WebAPI.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ILogger _logger;
        private IAuthenticationService _authenticationService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authenticationService = authenticationService ?? throw new ArgumentException(nameof(authenticationService));
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Authenticate(AuthenticationRequestDto authenticationRequest)
        {
            try
            {
                var serviceResponse = await _authenticationService.ValidateCredentials(authenticationRequest.EmailAddress, authenticationRequest.Password);
                return serviceResponse.Data != null ? Ok(serviceResponse.Data) : StatusCode(StatusCodes.Status403Forbidden, serviceResponse.Message);
            } catch (Exception ex)
            {
                _logger.LogCritical($"Exception while authenticating {authenticationRequest.EmailAddress}", ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
