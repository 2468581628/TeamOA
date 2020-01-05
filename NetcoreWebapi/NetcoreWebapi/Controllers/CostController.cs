using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel;
using NetcoreInfrastructure.Interface.Service.Cost;
using NetcoreInfrastructure.Model.Cost;
using NetcoreInfrastructure.ViewModel;
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
    public class CostController : ControllerBase
    {
        private readonly ILogger<CostController> _logger;
        private readonly AppConfig _appConfig;
        private readonly ICostService _costService;
        public CostController(ILogger<CostController> logger, IOptions<AppConfig> appConfig, ICostService costService)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _costService = costService;
        }

        /// <summary>
        /// 上单文件
        /// </summary>
        /// <param name="uploadFile"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ApiResult UploaderFile(IFormFile uploadFile)
        {
            CostFileNameModel info = new CostFileNameModel();
            if (uploadFile != null)
            {
                if (uploadFile.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string projectFileName = guid.ToString();
                    info.FileName = uploadFile.FileName;
                    info.NewFileName = projectFileName;
                    var filePath = "../File/File" + $@"\{projectFileName}";
                    try {
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            uploadFile.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                    catch (Exception ex) {
                        ex.ToString();
                    }
                    
                }
            }
            return new ApiResult(info);
        }

        /// <summary>
        /// 增加报销费用
        /// </summary>
        /// <param name="CostInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult AddCostData(AddCostVM CostInfo)
        {
            List<Claim> Claims = new JwtSecurityTokenHandler().ReadJwtToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")).Claims.ToList();
            var data=this._costService.AddCostData(Convert.ToInt32(Claims[1].Value), CostInfo);
            return new ApiResult(data);
        }

        /// <summary>
        /// 获取所有费用单
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ApiResult GetCostData()
        {
            List<Claim> Claims = new JwtSecurityTokenHandler().ReadJwtToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")).Claims.ToList();
            var data = this._costService.GetCostData(Convert.ToInt32(Claims[1].Value));
            return new ApiResult(data);
        }

    }
}