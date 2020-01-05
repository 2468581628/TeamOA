using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Cost;
using NetcoreInfrastructure.Model.Cost;
using NetcoreInfrastructure.ViewModel.Cost;

namespace NetcoreDal.DapperRepository
{
    public class CostRepository: ICostRepository
    {
        private readonly string _connectionString;
        private readonly CostSqlTemplate _costSqlTemplate;

        public CostRepository(IConfiguration configuration, IOptions<CostSqlTemplate> sql)
        {
            _connectionString = configuration.GetConnectionString("MainConnection");
            _costSqlTemplate = sql.Value;
        }

        public object AddCostData(int id, AddCostVM costInfo)
        {
            try {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Execute(_costSqlTemplate.AddCostData,new { USER_ID=id, COSTTYPE = costInfo.CostType, COSTCOUNT = costInfo.CostCount, FILENAME = costInfo.CostFileName.FileName, NEWFILENAME = costInfo.CostFileName.NewFileName, DATETIME =DateTime.Now, STATUS = "未审核" });
                    return result;
                }
            }
            catch (Exception ex) {
                ex.ToString();
                throw;
            }
        }

        public IEnumerable<CostModel> GetCostData(int id)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Query<CostModel>(_costSqlTemplate.GetCostData, new { USER_ID = id });
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
