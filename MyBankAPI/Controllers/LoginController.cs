using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBankAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")] 
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public LoginController(IConfiguration configuration, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }
        [HttpPost] 
        public async Task<IActionResult> Login([FromBody] UserModel loginModel)
        {
            var user =  await AuthenticateAsync(loginModel.Username, loginModel.Password);
            var userByName = await _userManager.FindByNameAsync(loginModel.Username);
            if (userByName != null)
            {
                var customUser = (User)userByName;
                return Ok(customUser);
            }
            return NotFound("User Not Found!");
        }
        private async Task<IdentityUser?> AuthenticateAsync (string username,string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByNameAsync(username);
                    if (currentUser == null)
                        return null;
                    return currentUser;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
      
    }
}
