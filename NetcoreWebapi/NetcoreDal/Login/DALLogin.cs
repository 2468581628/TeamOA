using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Model;

namespace NetcoreDal.Login
{
    public class DALLogin: ILoginRepository
    {
        private readonly string _connectionString;
        private readonly LoginSqlTemplate _memberSqlTemplate;

        public DALLogin(IConfiguration configuration, IOptions<LoginSqlTemplate> sql)
        {
            _connectionString = configuration.GetConnectionString("MainConnection");
            _memberSqlTemplate = sql.Value;
        }
        public IEnumerable<UserModel> UserLogin(string Account, string Password)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Query<UserModel>(_memberSqlTemplate.GetUserInfo,new { PASSWORD = Password , ACCOUNT = Account });
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
    }
}
