using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersApp.BLL.Services.Interface;
using UsersApp.DTOs.Request;

namespace FitFlexApp.API.Controllers
{
    [Route("/api/[controller]"), ApiController, Produces("application/json")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            /* EF data peristance w/ repository pattern */
            _userService = userService ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public async Task<ActionResult> GeUsers()
        {
            try
            {
                var serviceResponse = await _userService.GetUsersListAsync();
                return serviceResponse.Error ? StatusCode(serviceResponse.StatusCode, serviceResponse.Message) : Ok(serviceResponse.Data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while fetching user list", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserById(int userId)
        {
            try
            {
                var serviceResponse = await _userService.GetUserByIdAsync(userId);
                return serviceResponse.Error ? StatusCode(serviceResponse.StatusCode, serviceResponse.Message) : Ok(serviceResponse.Data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while fetching the user id {userId}", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserRequestDto user)
        {
            try
            {
                var serviceResponse = await _userService.CreateSingleUserAsync(user);
                if (serviceResponse.Error)
                {
                    return StatusCode(serviceResponse.StatusCode, serviceResponse.Message);
                }

                var activeUser = User.Claims.FirstOrDefault(c => c.Type.Equals("email_address"))?.Value;
                _logger.LogInformation($"HTTP POST request made by {activeUser}");
                return Ok(serviceResponse.Data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while creating the user id {user.UserId}", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserRequestDto user)
        {
            try
            {
                var serviceResponse = await _userService.UpdateSingleUserAsync(user);

                if (serviceResponse.Error)
                {
                    return StatusCode(serviceResponse.StatusCode);
                }

                var activeUser = User.Claims.FirstOrDefault(c => c.Type.Equals("email_address"))?.Value;
                _logger.LogInformation($"HTTP PUT request made by {activeUser}");
                return Ok(serviceResponse.Data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while updating the user, id {user.UserId}", ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
