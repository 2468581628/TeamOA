using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreDal.DapperRepository
{
    public class CheckRepository: ICheckRepository
    {
        private readonly string _connectionString;
        private readonly CheckSqlTemplate _checkSqlTemplate;

        public CheckRepository(IConfiguration configuration, IOptions<CheckSqlTemplate> sql)
        {
            _connectionString = configuration.GetConnectionString("MainConnection");
            _checkSqlTemplate = sql.Value;
        }
    }
}
