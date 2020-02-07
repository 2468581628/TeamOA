using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Model.Check;
using NetcoreInfrastructure.ViewModel.Check;
using Oracle.ManagedDataAccess.Client;
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

        public IEnumerable<CheckLeave> GetLeaveData()
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Query<CheckLeave>(_checkSqlTemplate.GetLeave);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public IEnumerable<CheckOvertime> GetOvertimeData()
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Query<CheckOvertime>(_checkSqlTemplate.GetOvertime);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public IEnumerable<CheckCost> GetCostData()
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Query<CheckCost>(_checkSqlTemplate.GetCost);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public int UpdateInfo(CheckStatus info)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    int result=0;
                    switch (info.Type)
                    {
                        case 1: result = connection.Execute(_checkSqlTemplate.UpdateLeave, new { status = info.Status, ID = info.ID }); break;
                        case 2: result = connection.Execute(_checkSqlTemplate.UpdateOvertime, new { status = info.Status, ID = info.ID }); break;
                        case 3: result = connection.Execute(_checkSqlTemplate.UpdateCost, new { status = info.Status, ID = info.ID }); break;
                    }
                    
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
