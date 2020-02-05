using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreDal.DapperRepository
{
    public class ArticlewagesRepository: IArticlewagesRepository
    {
        private readonly string _connectionString;
        private readonly ArticlewagesSqlTemplate _articlewagesSqlTemplate;

        public ArticlewagesRepository(IConfiguration configuration, IOptions<ArticlewagesSqlTemplate> sql)
        {
            _connectionString = configuration.GetConnectionString("MainConnection");
            _articlewagesSqlTemplate = sql.Value;
        }
    }
}
