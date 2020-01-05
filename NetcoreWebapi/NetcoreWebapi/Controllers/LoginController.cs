using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetcoreInfrastructure.ConfigModel;
using NetcoreInfrastructure.Interface.Service;
using NetcoreInfrastructure.Model;

namespace NetcoreWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly AppConfig _appConfig;
        private ILoginService _memberService;
        private readonly AppSettings _appSettings;

        public LoginController(ILogger<LoginController> logger, IOptions<AppConfig> appConfig, ILoginService memberService, IOptions<AppSettings> appsettings)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _memberService = memberService;
            _appSettings = appsettings.Value;
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(lg ll)
        {
            if (ll.Account == null|| ll.Password==null)
            {
                return BadRequest("Invalid client request");
            }
            var info = _memberService.UserLogin(ll.Account, ll.Password);
            if (info.Count()==1)
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, ll.Account),
                    new Claim(ClaimTypes.Sid,info.First().Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var serializeToken = tokenHandler.WriteToken(token);
                //user.Token = tokenHandler.WriteToken(token);
                return Ok(new UserModel()
                {
                    Account = ll.Account,
                    Name = info.First().Name,
                    Token = serializeToken
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
    public class lg
    { 
        public string Account { get; set; }
        public string Password { get; set; }
    }
}