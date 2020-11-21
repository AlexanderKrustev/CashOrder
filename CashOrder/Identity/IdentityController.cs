namespace CashOrder.Identity
{
    using System.Threading.Tasks;
    using Data.Models;
    using Infrastructure;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Models;

    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IIdentityService _identityService;
        private readonly AppSettings _appSettings;

        public IdentityController(UserManager<IdentityUser> userManager,
            IIdentityService identityService,
            IOptions<AppSettings> appSettings
            )
        {
            this._userManager = userManager;
            this._identityService = identityService;
            this._appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var user = new UserEntityModel()
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await this._userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var token = this._identityService.GenerateJwtToken(user, this._appSettings.Secret);
                return Created("https://localhost",token);
            }
          
            return BadRequest(result.Errors);              
        }


        [HttpPost]
        [Route(nameof(Login))]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            var email = model.Username;

            var user = await this._userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var passCheck = await this._userManager.CheckPasswordAsync(user, model.Password);

                if (passCheck)
                {
                    var token = this._identityService.GenerateJwtToken(user, this._appSettings.Secret);
                    return Ok(token);

                }
            }

            return Unauthorized("Wrong user or password");
        }
    }
}
