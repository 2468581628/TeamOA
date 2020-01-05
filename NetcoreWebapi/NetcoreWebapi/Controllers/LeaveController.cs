using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel;
using NetcoreInfrastructure.Interface.Service.Leave;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel;
using NetcoreInfrastructure.ViewModel.Leave;

namespace NetcoreWebapi.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly ILogger<LeaveController> _logger;
        private readonly AppConfig _appConfig;
        private readonly ILeaveService _leaveService;

        public LeaveController(ILogger<LeaveController> logger, IOptions<AppConfig> appConfig, ILeaveService leaveService)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _leaveService = leaveService;
        }

        /// <summary>
        /// 获取个人请假申请
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ApiResult GetLeaveData()
        {
            List<Claim> Claims = new JwtSecurityTokenHandler().ReadJwtToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")).Claims.ToList();
            var data = this._leaveService.GetLeaveData( Convert.ToInt32(Claims[1].Value));
            return new ApiResult(data);
        }

        /// <summary>
        /// 增加请假申请
        /// </summary>
        /// <param name="leaveModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ApiResult AddLeave(AddLeaveVM leaveModel)
        {
            List<Claim> Claims = new JwtSecurityTokenHandler().ReadJwtToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")).Claims.ToList();
            var code=this._leaveService.AddLeave(leaveModel, Convert.ToInt32(Claims[1].Value));
            return new ApiResult("0000");
        }
    }
}