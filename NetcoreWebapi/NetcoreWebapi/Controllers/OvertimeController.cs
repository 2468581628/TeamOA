using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel;
using NetcoreInfrastructure.Interface.Service.Overtime;
using NetcoreInfrastructure.ViewModel;
using NetcoreInfrastructure.ViewModel.Overtime;

namespace NetcoreWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OvertimeController : ControllerBase
    {
        private readonly ILogger<OvertimeController> _logger;
        private readonly AppConfig _appConfig;
        private IOvertimeService _overtimeService;

        public OvertimeController(ILogger<OvertimeController> logger, IOptions<AppConfig> appConfig, IOvertimeService overtimeService)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _overtimeService = overtimeService;
        }

        [HttpPost]
        [Authorize]
        public ApiResult AddOvertime(AddOvertimeVM info)
        {
            List<Claim> Claims = new JwtSecurityTokenHandler().ReadJwtToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")).Claims.ToList();
            var data = this._overtimeService.AddOvertime(info, Convert.ToInt32(Claims[1].Value));
            return new ApiResult(data);
        }

        public ApiResult GetOvertime()
        {
            List<Claim> Claims = new JwtSecurityTokenHandler().ReadJwtToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")).Claims.ToList();
            var data = this._overtimeService.GetOvertime( Convert.ToInt32(Claims[1].Value));
            return new ApiResult(data);
        }
    }
}