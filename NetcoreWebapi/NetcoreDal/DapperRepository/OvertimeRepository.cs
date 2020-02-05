using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Overtime;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreDal.DapperRepository
{
    public class OvertimeRepository: IOvertimeRepository
    {
        private readonly string _connectionString;
        private readonly OvertimeSqlTemplate _overtimeSqlTemplate;

        public OvertimeRepository(IConfiguration configuration, IOptions<OvertimeSqlTemplate> sql)
        {
            _connectionString = configuration.GetConnectionString("MainConnection");
            _overtimeSqlTemplate = sql.Value;
        }

        public int AddOvertime(AddOvertimeVM data, int userID)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Execute(_overtimeSqlTemplate.AddOvertime, new { STARTTTIME=data.StarttTime, ENDTIME=data.EndTime, INPUTVALUE=data.InputValue, USERID= userID, STATUS="未审核" });
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public IEnumerable<OvertimeModel> GetOvertime(int userId)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Query<OvertimeModel>(_overtimeSqlTemplate.GetOvertime, new { USERID = userId });
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
