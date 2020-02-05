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
using NetcoreInfrastructure.Interface.Service.Articlewages;
using NetcoreInfrastructure.ViewModel;

namespace NetcoreWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticlewagesController : ControllerBase
    {
        private readonly ILogger<ArticlewagesController> _logger;
        private readonly AppConfig _appConfig;
        private readonly IArticlewagesService _articlewagesService;
        public ArticlewagesController(ILogger<ArticlewagesController> logger, IOptions<AppConfig> appConfig, IArticlewagesService articlewagesService)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _articlewagesService = articlewagesService;
        }

        [Authorize]
        [HttpPost]
        public ApiResult UploaderFile(IFormFile uploadFile)
        {
            string projectFileName = null;
            if (uploadFile != null)
            {
                if (uploadFile.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    projectFileName = guid.ToString();
                    var filePath = "../File/Salary" + $@"\{projectFileName}";
                    try
                    {
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            uploadFile.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                }
            }
            var data = this._articlewagesService.ReadExcel("../File/Salary" + $@"\{projectFileName}");
            return new ApiResult(data);
        }

        [Authorize]
        [HttpGet]
        public ApiResult GetArticlewages()
        {
            List<Claim> Claims = new JwtSecurityTokenHandler().ReadJwtToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")).Claims.ToList();
            var data = this._articlewagesService.GetArticlewages(Convert.ToInt32(Claims[1].Value));
            return new ApiResult(data);
        }
    }
}