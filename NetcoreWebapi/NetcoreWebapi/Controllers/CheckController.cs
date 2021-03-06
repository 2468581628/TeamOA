﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel;
using NetcoreInfrastructure.Interface.Service.Check;
using NetcoreInfrastructure.Interface.Service.Cost;
using NetcoreInfrastructure.Model.Cost;
using NetcoreInfrastructure.ViewModel;
using NetcoreInfrastructure.ViewModel.Check;
using NetcoreInfrastructure.ViewModel.Cost;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace NetcoreWebapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private readonly ILogger<CheckController> _logger;
        private readonly AppConfig _appConfig;
        private readonly ICheckService _checkService;
        public CheckController(ILogger<CheckController> logger, IOptions<AppConfig> appConfig, ICheckService checkService)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _checkService = checkService;
        }

        [Authorize]
        [HttpGet]
        public ApiResult GetLeaveInfo()
        {
            var data = this._checkService.GetData(1);
            return new ApiResult(data);
        }

        [Authorize]
        [HttpGet]
        public ApiResult GetOvertime()
        {
            var data = this._checkService.GetData(2);
            return new ApiResult(data);
        }

        [Authorize]
        [HttpGet]
        public ApiResult GetCost()
        {
            var data = this._checkService.GetData(3);
            return new ApiResult(data);
        }

        [Authorize]
        [HttpPost]
        public ApiResult CheckInfo(CheckStatus info)
        {
            var data = this._checkService.UpdateInfo(info);
            return new ApiResult(data);
        }

        [HttpGet]
        public FileResult DownFile(string FileName)
        {

            return File(System.IO.File.OpenRead("../File/File/"+ FileName), "text/plain", "wendang.xlsx");
            //return new ApiResult(data);
        }
    }
}