using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Model.Articlewages;
using Oracle.ManagedDataAccess.Client;
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

        public int AddArticlewagesInfo(List<ReadArticlewagesModel> data)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            OracleTransaction transaction = connection.BeginTransaction();
            try
            {
                var InsOrderDetailsCode = connection.Execute(_articlewagesSqlTemplate.AddArticlewages, data, transaction);

                transaction.Commit();
                return InsOrderDetailsCode;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public IEnumerable<ReadArticlewagesModel> GetArticlewages(int userId)
        {
            
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Query<ReadArticlewagesModel>(userId != 1 ? _articlewagesSqlTemplate.GetInfo: _articlewagesSqlTemplate.GetInfoAdmin, new { USERID = userId });
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
