using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NetcoreBll.Articlewages;
using NetcoreBll.Check;
using NetcoreBll.Cost;
using NetcoreBll.Leave;
using NetcoreBll.Login;
using NetcoreBll.Member;
using NetcoreBll.Overtime;
using NetcoreDal.DapperRepository;
using NetcoreDal.Login;
using NetcoreInfrastructure.ConfigModel;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service;
using NetcoreInfrastructure.Interface.Service.Articlewages;
using NetcoreInfrastructure.Interface.Service.Check;
using NetcoreInfrastructure.Interface.Service.Cost;
using NetcoreInfrastructure.Interface.Service.Leave;
using NetcoreInfrastructure.Interface.Service.Member;
using NetcoreInfrastructure.Interface.Service.Overtime;
using System.Text;

namespace NetcoreWebapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //DI AppConfigs
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));

            //DI SqlTemplate
            services.Configure<LoginSqlTemplate>(Configuration.GetSection("SqlTemplate:LoginSqlTemplate"));
            services.Configure<MemberSqlTemplate>(Configuration.GetSection("SqlTemplate:MemberSqlTemplate"));
            services.Configure<LeaveSqlTemplate>(Configuration.GetSection("SqlTemplate:LeaveSqlTemplate"));
            services.Configure<CostSqlTemplate>(Configuration.GetSection("SqlTemplate:CostSqlTemplate"));
            services.Configure<CheckSqlTemplate>(Configuration.GetSection("SqlTemplate:CheckSqlTemplate"));
            services.Configure<OvertimeSqlTemplate>(Configuration.GetSection("SqlTemplate:OvertimeSqlTemplate"));
            services.Configure<ArticlewagesSqlTemplate>(Configuration.GetSection("SqlTemplate:ArticlewagesSqlTemplate"));

            //DI Service
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<ILoginService, Login>();
            services.AddTransient<ILeaveService, LeaveService>();
            services.AddTransient<ICostService, CostService>();
            services.AddTransient<ICheckService, CheckService>();
            services.AddTransient<IOvertimeService, OvertimeService>();
            services.AddTransient<IArticlewagesService, ArticlewagesService>();

            //DI Repository
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<ILoginRepository, DALLogin>();
            services.AddTransient<ILeaveRepository, LeaveRepository>();
            services.AddTransient<ICostRepository, CostRepository>();
            services.AddTransient<ICheckRepository, CheckRepository>();
            services.AddTransient<IOvertimeRepository, OvertimeRepository>();
            services.AddTransient<IArticlewagesRepository, ArticlewagesRepository>();


            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
                
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "OA Webapi";
                    document.Info.Description = "For OA";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "",
                        Email = string.Empty,
                        Url = "http://www.baidu.com/"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "",
                        Url = "http://www.百度.com/"
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Cors設定
            app.UseCors(builder => builder
               .WithOrigins("*")
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
