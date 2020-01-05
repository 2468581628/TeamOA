using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel;
using NetcoreInfrastructure.Interface.Service.Member;
using NetcoreInfrastructure.ViewModel;
using NetcoreInfrastructure.ViewModel.Member;

namespace NetcoreWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly AppConfig _appConfig;
        private IMemberService _memberService;

        public MemberController(ILogger<MemberController> logger, IOptions<AppConfig> appConfig, IMemberService memberService)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _memberService = memberService;
        }

        /// <summary>
        /// 获取全部用户数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ApiResult GetMemberData()
        {
            try {
                var data = this._memberService.GetMemberData();
                return new ApiResult(data);
            }
            catch (Exception ex)
            {
                return new ApiResult("444",ex.ToString());
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ApiResult UpdMemberData(UpdMemberVM updMember)
        {
            try
            {
                var data = this._memberService.UpdMemberData(updMember);
                return new ApiResult(data);
            }
            catch (Exception ex)
            {
                return new ApiResult("444", ex.ToString());
            }
        }

        /// <summary>
        /// 新增人员
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ApiResult InsMemberData(InsMemberVM insMember)
        {
            try
            {
                var data = this._memberService.InsMemberData(insMember);
                return new ApiResult(data);
            }
            catch (Exception ex)
            {
                return new ApiResult("444", ex.ToString());
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ApiResult UpdPasswordData(UpdPasswordVM updPassword)
        {
            try
            {
                var data = this._memberService.UpdPasswordData(updPassword);
                return new ApiResult(data);
            }
            catch (Exception ex)
            {
                return new ApiResult("444", ex.ToString());
            }
        }

        /// <summary>
        /// 更改账号状态
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ApiResult UpdStatusData(UpdStatusVM updStatus)
        {
            try
            {
                var data = this._memberService.UpdStatusData(updStatus);
                return new ApiResult(data);
            }
            catch (Exception ex)
            {
                return new ApiResult("444", ex.ToString());
            }
        }
    }
}