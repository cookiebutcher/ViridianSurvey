using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ViridianCode.ViridianSurvey.Services.Interfaces;
using ViridianCode.ViridianSurvey.Services.Interfaces.WebModels;

namespace ViridianSurveyWebApp.Controllers
{
    [Route("api/v1/users")]
    public class UserAccountsController : BaseController
    {
        private readonly IUserAccountService userAccountService;
        private readonly AppSettings appSettings;

        public UserAccountsController(IUserAccountService userAccountService, IOptions<AppSettings> appSettings)
        {
            this.userAccountService = userAccountService;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]WebUserAccount webUserAccount)
        {
            var user = userAccountService.Authenticate(webUserAccount.UserName, webUserAccount.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]WebUserAccount webUserAccount)
        {
            //var user = _mapper.Map<UserAccount>(webUserAccount);

            try
            {
                // save 
                userAccountService.Create(webUserAccount);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAccounts()
        {
            return Ok(await userAccountService.GetAllUserAccountsAsync());
        }
    }
}