using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegistrationController( UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel registrationModel)
        {
            User user = new User();
            user.Name = registrationModel.Name;
            user.IdentityNumber = registrationModel.IdentityNumber;
            user.PhoneNumber = registrationModel.PhoneNumber;
            user.DateOfBirth = registrationModel.DateOfBirth;
            user.LastName = registrationModel.LastName;
            user.UserName = registrationModel.Username;

            var result = await _userManager.CreateAsync(user,registrationModel.Password);

            if (result.Succeeded)
            {
                return Ok("User Registration Success");
            }
            return BadRequest("User Registration Filed!");
        }
    }
}
