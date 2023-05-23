using LinQ_practice_18_05.Model;
using LinQ_practice_18_05.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinQ_practice_18_05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;
        private readonly ILogger<AllContollersController> _logger;

        public AccountController(AccountService accountService, ILogger<AllContollersController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
           var response= await _accountService.signUp(model);
            _logger.LogInformation("sign up process is on going");
            if (response.Succeeded)
            {
                _logger.LogInformation("sign up successful");
                return Ok("Sign up successfull");
            }
            else
            {
                _logger.LogWarning("some issue in signing, please put the correct body in the request, or password must be contians upperCase, LowerCase,specialCharacter");
                return Unauthorized();
            }
               
        }
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] SignInModel model)
        {
            _logger.LogInformation("log in  proccess");
            var result = await _accountService.LoginAsync(model);

            if (string.IsNullOrEmpty(result))
            {
                _logger.LogWarning("some issue in loging, please put the correct body in the request, check password");
                return  Unauthorized();
            }
            _logger.LogInformation("loging successful");
            return Ok(result);
        }
        
    }
}
